# Projet2_M

## Description
Ce projet est une application ASP.NET Core MVC qui affiche :
- la météo actuelle de Montréal avec l’API OpenWeather
- les films populaires avec l’API TMDB

## Technologies utilisées
- ASP.NET Core MVC
- C#
- HttpClient
- IMemoryCache
- Bootstrap

## APIs utilisées
- OpenWeather
- TMDB

//labib
## Configuration
Les clés API sont stockées dans le fichier `appsettings.json` sous la section `ApiKeys`.
--J’ai réalisé la partie dashboard avec deux APIs publiques, configuré les clés dans appsettings.json,
utilisé HttpClient, ajouté IMemoryCache avec expiration de 5 minutes, géré les erreurs,
puis affiché les données météo et les films populairesdans une vue MVC.
Les clés API utilisées dans ce projet proviennent des plateformes officielles OpenWeather et TMDB.
Elles ont été obtenues après inscription et création d’un compte sur chaque site, puis configurées dans `appsettings.json`.

## Fonctionnalités
- récupération des données météo
- récupération des films populaires
- affichage dans une vue MVC
- gestion des erreurs
- cache mémoire de 5 minutes

## Auteur
Projet réalisé dans le cadre du Projet 2 (labib, mohamed , lydianne)