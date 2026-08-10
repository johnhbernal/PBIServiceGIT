(() => {
  const TOKEN_KEY = 'pbi.teaching.token';
  const USER_KEY = 'pbi.teaching.user';

  const VIEWS = [
    { id: 'lineas', title: 'Líneas', path: '/api/Lineas', subtitle: 'Unidades de negocio demo (seed InMemory)', columns: [
      { key: 'linea', label: 'Línea' },
      { key: 'undNegocio', label: 'Und. negocio' },
      { key: 'undNegocioNombre', label: 'Nombre' },
    ]},
    { id: 'products', title: 'Products', path: '/api/Products', subtitle: 'Catálogo inventario teaching — incluye sin stock', columns: [
      { key: 'productId', label: 'Id' },
      { key: 'name', label: 'Nombre' },
      { key: 'category', label: 'Categoría' },
      { key: 'unitPrice', label: 'Precio', fmt: 'money' },
      { key: 'availableQuantity', label: 'Stock', fmt: 'stock' },
    ]},
    { id: 'productos', title: 'Productos dim', path: '/api/Productos', subtitle: 'Dimensión materiales (PBI-style)', columns: [
      { key: 'idMaterial', label: 'Material' },
      { key: 'producto', label: 'Producto' },
      { key: 'nombreGrArticulos', label: 'Grupo' },
      { key: 'agrupacionMarca', label: 'Marca' },
    ]},
    { id: 'clientes', title: 'Clientes', path: '/api/Clientes', subtitle: 'Clientes demo para validación visual', columns: [
      { key: 'idCliente', label: 'Id' },
      { key: 'nombreComercial', label: 'Nombre comercial' },
    ]},
    { id: 'sociedades', title: 'Sociedades', path: '/api/Sociedades', subtitle: 'Sociedades teaching', columns: [
      { key: 'idSociedad', label: 'Id' },
      { key: 'sociedad', label: 'Sociedad' },
    ]},
    { id: 'ventascp', title: 'Ventas × producto', path: '/api/VentClienProductos', subtitle: 'Hechos de venta agregados (seed)', columns: [
      { key: 'linea', label: 'Línea' },
      { key: 'producto', label: 'Producto' },
      { key: 'idMaterial', label: 'Material' },
      { key: 'ventaML', label: 'Venta ML', fmt: 'money' },
    ]},
  ];

  const state = {
    view: 'lineas',
    rows: null,
    error: '',
    loading: false,
  };

  function getToken() { return sessionStorage.getItem(TOKEN_KEY) || ''; }
  function getUser() {
    try { return JSON.parse(sessionStorage.getItem(USER_KEY) || 'null'); } catch { return null; }
  }

  function fmt(value, kind) {
    if (kind === 'money') {
      return new Intl.NumberFormat('es-CO', { style: 'currency', currency: 'COP', maximumFractionDigits: 0 }).format(Number(value || 0));
    }
    if (kind === 'stock') {
      const n = Number(value || 0);
      return n > 0 ? `${n} · OK` : `${n} · SIN STOCK`;
    }
    return value ?? '—';
  }

  async function api(path, options = {}) {
    const headers = { 'Content-Type': 'application/json', ...(options.headers || {}) };
    const token = getToken();
    if (token) headers.Authorization = `Bearer ${token}`;
    const res = await fetch(path, { ...options, headers });
    if (res.status === 401) {
      sessionStorage.removeItem(TOKEN_KEY);
      sessionStorage.removeItem(USER_KEY);
      throw new Error('401 — sesión requerida o token inválido (AuthZ OK)');
    }
    if (!res.ok) {
      const text = await res.text();
      throw new Error(`${res.status} ${text || res.statusText}`);
    }
    if (res.status === 204) return null;
    return res.json();
  }

  async function login(email, password) {
    const data = await api('/api/Token', {
      method: 'POST',
      body: JSON.stringify({ email, password }),
    });
    sessionStorage.setItem(TOKEN_KEY, data.token);
    sessionStorage.setItem(USER_KEY, JSON.stringify({ email }));
    return data;
  }

  function logout() {
    sessionStorage.removeItem(TOKEN_KEY);
    sessionStorage.removeItem(USER_KEY);
    state.rows = null;
    render();
  }

  async function loadView(id) {
    const view = VIEWS.find((v) => v.id === id) || VIEWS[0];
    state.view = view.id;
    state.loading = true;
    state.error = '';
    state.rows = null;
    render();
    try {
      const data = await api(view.path);
      state.rows = Array.isArray(data) ? data : (data?.value || []);
    } catch (e) {
      state.error = e.message || String(e);
      state.rows = [];
    } finally {
      state.loading = false;
      render();
    }
  }

  function renderLogin() {
    return `
      <div class="login-screen">
        <div class="login-card">
          <h1 class="brand">PBI Teaching Lab</h1>
          <p class="tagline">Front de enseñanza sobre API InMemory + directorio simulado. Sin SQL/LDAP reales.</p>
          <div class="hint">
            <strong>Credenciales demo</strong><br/>
            Admin: <code>admin@demo.local</code> / <code>Admin123!</code><br/>
            Seller: <code>seller@demo.local</code> / <code>Seller123!</code><br/>
            Tras login debes ver tablas con filas seed (no chrome vacío).
          </div>
          <div id="login-error"></div>
          <form id="login-form">
            <label for="email">Correo</label>
            <input id="email" name="email" type="email" value="admin@demo.local" autocomplete="username" required />
            <label for="password">Contraseña</label>
            <input id="password" name="password" type="password" value="Admin123!" autocomplete="current-password" required />
            <button class="btn btn-primary" type="submit">Entrar al laboratorio</button>
          </form>
          <p class="tagline" style="margin-top:16px;margin-bottom:0">
            API docs: <a href="/swagger" target="_blank" rel="noopener">Swagger</a>
            · Health: <a href="/health" target="_blank" rel="noopener">/health</a>
          </p>
        </div>
      </div>`;
  }

  function renderShell() {
    const user = getUser();
    const view = VIEWS.find((v) => v.id === state.view) || VIEWS[0];
    const rows = state.rows || [];
    const stats = `
      <div class="stats">
        <div class="stat"><div class="k">Filas vista</div><div class="v">${state.loading ? '…' : rows.length}</div></div>
        <div class="stat"><div class="k">AuthZ</div><div class="v" style="font-size:1rem"><span class="badge badge-ok">JWT OK</span></div></div>
        <div class="stat"><div class="k">Datos</div><div class="v" style="font-size:1rem"><span class="badge badge-lab">InMemory</span></div></div>
      </div>`;

    let body = '';
    if (state.loading) body = `<div class="loading">Cargando ${view.title}…</div>`;
    else if (state.error) body = `<div class="error" style="margin:16px">${state.error}</div>`;
    else if (!rows.length) body = `<div class="empty">Sin datos en esta vista. El seed debería llenar Líneas/Products/Clientes — revisa que la API haya arrancado con TeachingDataSeeder.</div>`;
    else {
      body = `<table>
        <thead><tr>${view.columns.map((c) => `<th>${c.label}</th>`).join('')}</tr></thead>
        <tbody>
          ${rows.map((row) => `<tr>${view.columns.map((c) => {
            const raw = row[c.key];
            const shown = fmt(raw, c.fmt);
            const stockClass = c.fmt === 'stock' && Number(raw) === 0 ? ' style="color:var(--danger);font-weight:600"' : '';
            return `<td${stockClass}>${shown}</td>`;
          }).join('')}</tr>`).join('')}
        </tbody>
      </table>`;
    }

    return `
      <div class="shell">
        <header class="topbar">
          <h1>PBI Teaching Lab</h1>
          <div class="meta">
            <span class="badge badge-lab">Teaching</span>
            <span class="badge badge-ok">AuthZ server-side</span>
            <span>${user?.email || 'sesión'}</span>
            <button class="btn btn-ghost" type="button" id="btn-logout">Salir</button>
          </div>
        </header>
        <div class="layout">
          <nav>
            ${VIEWS.map((v) => `<button type="button" data-view="${v.id}" class="${v.id === state.view ? 'active' : ''}">${v.title}</button>`).join('')}
          </nav>
          <main>
            ${stats}
            <section class="panel">
              <div class="panel-head">
                <h2>${view.title}</h2>
                <p>${view.subtitle}</p>
              </div>
              ${body}
              <div class="foot">
                <span>Endpoint: <code>${view.path}</code></span>
                <span class="links">
                  <a href="/swagger" target="_blank" rel="noopener">Swagger</a>
                  <a href="http://localhost:3000" target="_blank" rel="noopener">Practica UI</a>
                </span>
              </div>
            </section>
          </main>
        </div>
      </div>`;
  }

  function bind() {
    const loginForm = document.getElementById('login-form');
    if (loginForm) {
      loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const err = document.getElementById('login-error');
        err.innerHTML = '';
        const email = document.getElementById('email').value.trim();
        const password = document.getElementById('password').value;
        try {
          await login(email, password);
          await loadView('lineas');
        } catch (ex) {
          err.innerHTML = `<div class="error">${ex.message || ex}</div>`;
        }
      });
    }

    document.getElementById('btn-logout')?.addEventListener('click', logout);
    document.querySelectorAll('nav button[data-view]').forEach((btn) => {
      btn.addEventListener('click', () => loadView(btn.dataset.view));
    });
  }

  function render() {
    const root = document.getElementById('app');
    root.innerHTML = getToken() ? renderShell() : renderLogin();
    bind();
  }

  if (getToken()) loadView(state.view);
  else render();
})();
