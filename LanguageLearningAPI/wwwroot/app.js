"use strict";

const API = "/api/Api";
const app = document.getElementById("app");

// ---- tiny helpers ---------------------------------------------------------
const el = (sel) => document.querySelector(sel);
const esc = (s) =>
    String(s ?? "").replace(/[&<>"']/g, (c) => ({
        "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;",
    }[c]));

async function getJSON(path) {
    const res = await fetch(API + path);
    if (!res.ok) throw new Error(`${res.status} ${res.statusText}`);
    return res.json();
}

function showError(err) {
    app.innerHTML = `<div class="error">⚠️ Could not load data: ${esc(err.message)}</div>`;
}

// ---- data (cached for the session) ---------------------------------------
let groups = null;     // [{groupID, groupName, description, sourceLanguage, targetLanguage}]
let pairsByGroup = null; // { [groupID]: [pair, ...] }

async function loadData() {
    const [g, pairs] = await Promise.all([
        getJSON("/translation-groups"),
        getJSON("/translation-pairs"),
    ]);
    groups = g;
    pairsByGroup = {};
    for (const p of pairs) {
        (pairsByGroup[p.groupID] ??= []).push(p);
    }
}

// ---- views ----------------------------------------------------------------
function renderGroups() {
    if (!groups.length) {
        app.innerHTML = `<p class="empty">No translation groups yet.</p>`;
        return;
    }
    const cards = groups.map((g) => {
        const count = (pairsByGroup[g.groupID] || []).length;
        return `
        <div class="card" data-group="${g.groupID}">
            <h3>${esc(g.groupName)}</h3>
            <p>${esc(g.description || "")}</p>
            <div class="card-meta">
                <span class="badge">${esc(g.sourceLanguage)} → ${esc(g.targetLanguage)}</span>
                <span class="count">${count} ${count === 1 ? "item" : "items"}</span>
            </div>
        </div>`;
    }).join("");

    app.innerHTML = `
        <h2 class="view-title">Translation groups</h2>
        <p class="subtitle">Pick a set to browse or practice.</p>
        <div class="grid">${cards}</div>`;

    app.querySelectorAll(".card").forEach((c) =>
        c.addEventListener("click", () => renderGroupDetail(Number(c.dataset.group))));
}

function renderGroupDetail(groupId) {
    const g = groups.find((x) => x.groupID === groupId);
    const pairs = pairsByGroup[groupId] || [];
    const rows = pairs.map((p) => `
        <tr>
            <td>${esc(p.sourceContent)}</td>
            <td>${esc(p.targetContent)}</td>
            <td><span class="type-tag">${esc(p.type)}</span></td>
        </tr>`).join("");

    app.innerHTML = `
        <div class="crumbs"><a id="back">← All groups</a></div>
        <h2 class="view-title">${esc(g.groupName)}</h2>
        <p class="subtitle">
            <span class="badge">${esc(g.sourceLanguage)} → ${esc(g.targetLanguage)}</span>
            &nbsp; ${esc(g.description || "")}
        </p>
        <div class="toolbar">
            <button class="btn primary" id="practice" ${pairs.length ? "" : "disabled"}>▶ Practice (${pairs.length})</button>
        </div>
        ${pairs.length ? `
        <table>
            <thead><tr>
                <th>${esc(g.sourceLanguage)}</th>
                <th>${esc(g.targetLanguage)}</th>
                <th>Type</th>
            </tr></thead>
            <tbody>${rows}</tbody>
        </table>` : `<p class="empty">No pairs in this group yet.</p>`}`;

    el("#back").addEventListener("click", renderGroups);
    const practice = el("#practice");
    if (practice && pairs.length) {
        practice.addEventListener("click", () => renderPractice(g, pairs));
    }
}

function renderPractice(g, pairs) {
    let i = 0;
    let revealed = false;

    function draw() {
        const p = pairs[i];
        app.innerHTML = `
            <div class="crumbs"><a id="back">← ${esc(g.groupName)}</a></div>
            <div class="flash-wrap">
                <div class="progress">Card ${i + 1} / ${pairs.length}</div>
                <div class="flashcard" id="card">
                    <div class="flash-lang">${esc(g.sourceLanguage)}</div>
                    <div class="flash-term">${esc(p.sourceContent)}</div>
                    ${revealed
                        ? `<div class="flash-lang" style="margin-top:18px">${esc(g.targetLanguage)}</div>
                           <div class="flash-answer">${esc(p.targetContent)}</div>`
                        : `<div class="flash-hint">Click to reveal</div>`}
                </div>
                <div class="flash-controls">
                    <button class="btn" id="prev" ${i === 0 ? "disabled" : ""}>← Prev</button>
                    <button class="btn primary" id="next" ${i === pairs.length - 1 ? "disabled" : ""}>Next →</button>
                </div>
            </div>`;

        el("#back").addEventListener("click", () => renderGroupDetail(g.groupID));
        el("#card").addEventListener("click", () => { revealed = !revealed; draw(); });
        el("#prev").addEventListener("click", () => { if (i > 0) { i--; revealed = false; draw(); } });
        el("#next").addEventListener("click", () => { if (i < pairs.length - 1) { i++; revealed = false; draw(); } });
    }
    draw();
}

// ---- boot -----------------------------------------------------------------
document.getElementById("homeLink").addEventListener("click", () => {
    if (groups) renderGroups();
});

(async function init() {
    try {
        await loadData();
        renderGroups();
    } catch (err) {
        showError(err);
    }
})();
