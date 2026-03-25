# 📊 Projet ASP.NET Core — Tableau de Bord Multi-APIs

Application web **ASP.NET Core (.NET 8)** affichant un tableau de bord dynamique qui consomme deux APIs publiques :
- 🌤️ OpenWeatherMap (météo)
- 🎬 TMDB (films)

👉 Objectif : afficher la météo de **Montréal** et les **films populaires en temps réel**.

🔗 **Dépôt GitHub :**  
https://github.com/emkach01/Projet2.

---

## 👥 Équipe et répartition des tâches

### 👤 Mohamed — APIs et Services
- Sélection de 2 APIs publiques (OpenWeatherMap, TMDB)
- Création des services :
  - `WeatherService.cs`
  - `MovieService.cs`
- Utilisation de `IHttpClientFactory` (`AddHttpClient<T>()`)
- Création des modèles C# :
  - `WeatherResponse`, `MainInfo`, `WeatherInfo`, `WindInfo`
  - `MovieResponse`, `Movie`
- Désérialisation avec `GetFromJsonAsync<T>()`
- Tests des appels API

---

### 👤 Labib — Backend ASP.NET (Controller + Cache)
- Création de `HomeController.cs`
- Implémentation du cache avec `IMemoryCache` :
  - Météo : 5 minutes
  - Films : 30 minutes
- Gestion des erreurs (`try/catch`)
- Configuration dans `Program.cs` :
  - `AddMemoryCache()`
  - `AddHttpClient<WeatherService>()`
  - `AddHttpClient<MovieService>()`
- Configuration des clés API (`appsettings.json`)
- Transmission des données avec :
  - `ViewBag.Weather`
  - `ViewBag.Movies`

---

### 👤 Lydianne — Interface Utilisateur (Frontend)
- Création de `Views/Home/Index.cshtml`
- Affichage dynamique :
  - 🌤️ Météo : température, ressenti, humidité, vent, icône
  - 🎬 Films : titre, affiche, note, date de sortie
- Design avec **Bootstrap 5**
- Gestion des erreurs et états vides
- JavaScript :
  - Bouton « Rafraîchir »
  - Rafraîchissement automatique (5 min)

---

### 🤝 Travail commun
- Utilisation de GitHub (branches + commits)
- Tests du projet
- Rédaction de la documentation (`README.md`)

---

## 🧾 Description du projet

| Section | API | Données affichées |
|--------|-----|------------------|
| 🌤️ Météo | OpenWeatherMap | Température, ressenti, humidité, vent, description |
| 🎬 Films | TMDB | Titre, affiche, note moyenne, date de sortie |

---

## 🛠️ Technologies utilisées

- **Backend :** ASP.NET Core MVC (.NET 8, C# 12)
- **HTTP :** `IHttpClientFactory`, `GetFromJsonAsync<T>()`
- **Cache :** `IMemoryCache`
- **Frontend :** Razor + Bootstrap 5 + JavaScript
- **JSON :** `System.Text.Json` + `[JsonPropertyName]`

---

## 🚀 Lancer le projet

### 1. Cloner le dépôt
```bash
git clone https://github.com/emkach01/Projet2..git
cd Projet2._finale

### 2. Configurer les clés API
Modifiez `appsettings.json` à la racine du projet :
{ "ApiKeys": { "WeatherApiKey": "0886ba7d95112522977a6172d8b10d24", "TmdbApiKey": "8ed2fcb1031415c925b417420bc00f62" } }

### 3. Restaurer les dépendances et lancer

dotnet restore dotnet run

### 4. Accéder à l'application
Ouvrez votre navigateur à l'adresse affichée dans la console (ex : `https://localhost:7034`).

---

## 🌐 APIs utilisées

| API | URL de base | Endpoint utilisé |
|---|---|---|
| OpenWeatherMap | `https://api.openweathermap.org` | `/data/2.5/weather?q=Montreal&units=metric` |
| TMDB | `https://api.themoviedb.org` | `/3/movie/popular?language=en-US&page=1` |

---

## 📁 Structure du projet

Projet2._finale/
│
├── Controllers/
│   └── HomeController.cs
│
├── Models/
│   ├── WeatherResponse.cs
│   ├── MovieResponse.cs
│   └── ErrorViewModel.cs
│
├── Services/
│   ├── WeatherService.cs
│   └── MovieService.cs
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   └── _ViewStart.cshtml
│
├── wwwroot/
├── Program.cs
├── appsettings.json
└── README.md

## ⚙️ Fonctionnalités techniques

| Fonctionnalité | Implémentation | Fichier |
|---|---|---|
| Appels HTTP typés | `AddHttpClient<T>()` | `Program.cs` |
| Désérialisation JSON | `GetFromJsonAsync<T>()` + `[JsonPropertyName]` | `Services/*.cs` + `Models/*.cs` |
| Cache mémoire | `IMemoryCache.GetOrCreateAsync()` | `HomeController.cs` |
| TTL météo | 5 minutes | `HomeController.cs` |
| TTL films | 30 minutes | `HomeController.cs` |
| Gestion d'erreur | `try/catch` → retourne objet vide | `Services/*.cs` |
| Rafraîchissement auto | `setInterval()` toutes les 5 min | `Index.cshtml` |
| Design responsive | Bootstrap 5 (cards, grid, badges) | `Index.cshtml` |

---

## 🤖 Utilisation d'outils d'intelligence artificielle

Dans le cadre de ce projet, l'équipe a utilisé **GitHub Copilot** (intégré à Visual Studio 2022) et **ChatGPT** comme outils d'assistance au développement. Ces outils n'ont **pas** généré le projet à notre place, mais nous ont aidés dans les situations suivantes :

### 📚 Compréhension de concepts
- Comprendre le fonctionnement de `IHttpClientFactory` et pourquoi l'utiliser plutôt qu'un `new HttpClient()`.
- Comprendre le rôle de `[JsonPropertyName]` pour mapper les noms JSON (snake_case) vers les propriétés C# (PascalCase).
- Comprendre le principe du cache mémoire (`IMemoryCache`) : pourquoi l'utiliser, comment configurer le TTL, et quel problème concret il résout (quotas API, performance).

### 🐛 Correction d'erreurs
- **`View 'Index' was not found`** → Copilot nous a expliqué que la route par défaut pointait vers `HomeController` mais que la vue était dans `Views/Dashboard/`. Solution : créer `Views/Home/Index.cshtml`.
- **`WeatherInfo does not contain a definition for 'Icon'`** → Copilot a identifié que la propriété `Icon` manquait dans le modèle C# alors que la vue l'utilisait et que l'API OpenWeather la renvoyait.
- **`Movie does not contain a definition for 'VoteAverage'`** → Même problème : les propriétés `VoteAverage`, `PosterPath` et `ReleaseDate` manquaient dans le modèle `Movie`.
- **Erreurs d'interpolation Razor** avec les URLs d'images (`@@` mal interprété) → Copilot a proposé d'utiliser `@(...)` pour construire les URLs proprement.

### 📝 Rédaction de la documentation
- Structuration et rédaction de ce fichier `README.md` avec l'aide de Copilot et ChatGPT pour s'assurer que toutes les sections sont complètes et claires.

### ⚠️ Transparence
Tout le code du projet a été **compris, revu et validé** par les membres de l'équipe avant d'être intégré. Les outils d'IA ont servi d'assistant pédagogique, pas de remplacement.