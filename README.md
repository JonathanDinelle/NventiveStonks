# Introduction 
Test technique nventive. Début de solution pour générer des discussions techniques.

Le diagramme C2 se retrouve [ici](https://drive.google.com/file/d/1Z4DghrAxBZs2XcfMfxOBJdCngyrOnHrY/view?usp=sharing).



# Solution Proposé

Un micro-service StocksService

Un micro-service OrdersService

Un micro-service BrokersService



Hypothétiquement:

Un micro-service de Polling qui va chercher les données des stocks à chaque X temps. Web job/azure function qui pousse des updates de prix à notre StocksService (par messaging ou directement en utilisant l'API).



## Pourquoi Micro Services

La mise à jour des prix risque d'être fréquemment appelé. Ça permetterait de scale indépendament des services "Orders et Brokers" qui lui risque d'être plus à la demande. Ils ont aussi 2 besoin différents (hypothèse que le service de stocks est appelé chaque x nombre de temps par un service externe pour garder une mise à jour de prix en plus d'être utilisé par l'application client) vs Orders et Brokers qui ne sont utilisés que par l'application cliente.



## Stock Service

**Note:** *Ce service pourrait probablement être substitué par un API de données existantes (style yahoo finance). Je prend pour acquis que pour les fins de l'exercices, je dois implémenter une façon de garder des traces des prix. Dépendamment de ce qu'offre les différents API existants, la solution suivante pourrait être gardé partiellement ou même, pas du tout.* *Ce serait probablement une POC à effectuer dans le processus de vente pour voir ce qu'offre le marché, les coûts, si nous avons réellement besoins de projections et d'un historique complet de prix, etc.*



Stock service utiliserait du event sourcing pour la mise à jours des prix et l'ajout de stocks. Ça amenerait plusieurs avantages:

- Garder un historique des prix
- Permet de faire des projections pour des "read" rapides de l'application cliente (Example average 30 jours, lowest, highest, etc.)
- Event driven (updates de prix d'un système externe)



**Hypothèse:** Pourrait être branché sur un micro-service de Polling qui va chercher les données des stocks à chaque X temps du style Web Job.



## Order Service

App standard permettant de faire du CRUD. Pas en event sourcing parce qu'ici ça rajouterait une complexité supplémentaire sans vraiment de gain fonctionnel. Une BD SQL tout simple en arrière pour persister les données.



# Raccourci pour test technique

- Aucune DB, tout est en mémoire (List & Dictionnaires)
  - Pas d'event store optimisé, implémentation custom rapide in memory
- Pas de SignalR pour afficher les changements de prix en temps réel (pas un requis)
- Pas de API Gateway
- Pas d'authentification
- Pas de polling pour aller chercher les prix. Les prix et l'historique sont générés et gardé en mémoire lorsque l'on démarre le projet
- Pas de paging
- Recherche fait uniquement frontend
- Pas de redux
- Peu de unit tests
  - Quelques dates DateTime.UtcNow flottant au lieu d'être dans un providers
- Pas de config eslint/editorconfig fancy



# Getting Started
### Backend

Aucun setup particulier, simplement démarrer l'api de Stocks. Le seeding in-memory est fait automatiquement.

Swagger va ouvrir automatiquement.

### Frontend

Setup standard NextJs/react

- Renommer le fichier env.sample par .env.local
- Rouler les commandes suivante 

```shell
npm i
npm run dev
```

La web app sera accessible sur http://localhost:3000