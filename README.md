# ImageDup

**Détection d'images similaires et doublons avec intelligence artificielle**

ImageDup est une application Windows qui analyse un dossier d'images et détecte automatiquement les images similaires ou en doublon en utilisant l'intelligence artificielle (modèle CLIP d'OpenAI).

---

## Fonctionnalités

### 🔍 Analyse intelligente
- Détection des images similaires basée sur le contenu visuel (pas seulement les métadonnées)
- Utilisation du modèle ONNX CLIP (Vision Transformer) d'OpenAI
- Score de similarité en pourcentage pour chaque paire d'images
- Analyse récursive de tous les sous-dossiers

### ⚡ Performance optimisée
- **Traitement parallèle** : utilise tous les cœurs du processeur
- **Cache des embeddings** : chaque image n'est analysée qu'une seule fois
- **LockBits optimisé** : traitement ultra-rapide des pixels
- **Session ONNX réutilisée** : pas de rechargement du modèle
- Annulation possible à tout moment

### 🎨 Interface moderne
- Interface Metro moderne et épurée
- Prévisualisation des images côte à côte
- Zoom sur les images (clic ou double-clic)
- Affichage des noms de fichiers et tailles
- Progression en temps réel avec estimation du temps restant

### 🗑️ Gestion des doublons
- Suppression directe depuis l'interface
- Boutons de suppression pour chaque image
- Envoi à la corbeille (récupération possible)
- Mise à jour automatique de la liste après suppression

---

## Prérequis

- Windows 7 ou supérieur
- .NET Framework 4.8.1
- Processeur x64

---

## Installation

1. Téléchargez la dernière version depuis les releases
2. Décompressez l'archive
3. Lancez `ImageDup.exe`

Le modèle ONNX CLIP est inclus dans l'application (embarqué).

---

## Utilisation

### 1. Sélectionner un dossier
Cliquez sur **"Sélectionner un dossier"** et choisissez le dossier contenant vos images à analyser.

### 2. Lancer l'analyse
Cliquez sur **"Analyser"** pour démarrer la détection des images similaires.

L'analyse affiche :
- Le nombre d'images trouvées
- La progression (X/Y comparaisons)
- Le temps restant estimé

### 3. Consulter les résultats
Les résultats s'affichent triés par similarité décroissante :
- **Image 1** : chemin de la première image
- **Image 2** : chemin de la deuxième image
- **Similarité** : score en pourcentage (100% = identiques)

### 4. Prévisualiser et supprimer
- Cliquez sur une ligne pour prévisualiser les deux images
- Utilisez les boutons 🗑️ pour supprimer l'image de votre choix
- Cliquez sur une image pour l'agrandir (Échap pour fermer)

---

## Technologies utilisées

### Intelligence artificielle
- **ONNX Runtime** : exécution du modèle IA
- **CLIP (ViT-B/32)** : modèle de vision d'OpenAI
- **Embeddings** : représentation vectorielle des images (512 dimensions)
- **Similarité cosinus** : calcul de la distance entre vecteurs

### Interface graphique
- **Windows Forms** : framework d'interface
- **MetroFramework** : thème moderne
- **GDI+** : manipulation d'images

### Optimisations
- **Parallel.ForEach** : parallélisation multi-cœurs
- **ConcurrentDictionary** : cache thread-safe
- **LockBits unsafe** : accès direct à la mémoire
- **CancellationToken** : annulation coopérative

---

## Architecture technique

### Flux de traitement

```
Image → Redimensionnement (224x224)
      → Normalisation (CLIP mean/std)
      → Tenseur ONNX [1,3,224,224]
      → Modèle CLIP
      → Embedding [512 floats]
      → Cache (réutilisation)

Embedding1 + Embedding2 → Similarité cosinus → Score %
```

### Cache des embeddings

Pour **70 images** et **2415 comparaisons** :
- **Sans cache** : 4830 calculs ONNX (70×69)
- **Avec cache** : 70 calculs ONNX
- **Gain** : ~69x plus rapide

### Comparaison des performances

| Optimisation | Avant | Après | Gain |
|-------------|-------|-------|------|
| Session ONNX | Créée à chaque fois | Réutilisée | ~10x |
| Embeddings | Recalculés | Cachés | ~69x |
| Pixels | GetPixel() | LockBits unsafe | ~50x |
| **Total** | Plusieurs minutes | Quelques secondes | **~100x** |

---

## Format des images supportées

- JPEG (.jpg, .jpeg)
- PNG (.png)
- BMP (.bmp)
- GIF (.gif)

---

## Calcul du score de similarité

Le score utilise la **similarité cosinus** entre les embeddings :

```
similarité = (A · B) / (||A|| × ||B||)
```

- **100%** : images identiques ou quasi-identiques
- **90-99%** : très similaires (même scène, légères variations)
- **80-89%** : similaires (même sujet, angles différents)
- **70-79%** : ressemblance modérée
- **< 70%** : images différentes

---

## Limitations

- Le modèle CLIP détecte la similarité **visuelle/sémantique**, pas les doublons binaires exacts
- Les images très différentes visuellement mais similaires sémantiquement peuvent avoir un score élevé
- Le temps d'analyse dépend du nombre d'images : O(n²) comparaisons

### Nombre de comparaisons

| Images | Comparaisons | Temps estimé (avec optimisations) |
|--------|-------------|-----------------------------------|
| 10 | 45 | < 1 sec |
| 50 | 1 225 | ~5 sec |
| 100 | 4 950 | ~20 sec |
| 200 | 19 900 | ~1 min 20 sec |
| 500 | 124 750 | ~8 min |

---

## Dépannage

### L'analyse est lente
- Assurez-vous d'utiliser la dernière version avec les optimisations
- Vérifiez que le code unsafe est activé (compilation)
- Fermez les autres applications gourmandes en ressources

### Erreur "Modèle ONNX introuvable"
- Vérifiez que le fichier `openai.clip-vit-base-patch32.onnx` est présent
- Réinstallez l'application si nécessaire

### Erreur de mémoire
- Réduisez le nombre d'images analysées
- Fermez l'application et relancez-la

---

## Licence

Ce projet utilise :
- **ONNX Runtime** (MIT License)
- **MetroFramework** (MIT License)
- **CLIP Model** d'OpenAI (MIT License)

---

## Développement

### Compiler le projet

```bash
# Prérequis
- Visual Studio 2019 ou supérieur
- .NET Framework 4.8.1 SDK

# Restaurer les packages NuGet
nuget restore ImageDup.sln

# Compiler
msbuild ImageDup.sln /p:Configuration=Release /p:Platform=AnyCPU
```

### Structure du projet

```
ImageDup/
├── MainForm.cs              # Interface principale
├── MainForm.Designer.cs     # Définition de l'UI
├── ImageComparisonService.cs # Service d'analyse IA
├── ComparisonResult.cs      # Modèle de données
├── Program.cs               # Point d'entrée
├── Settings.cs              # Configuration
└── models/
    └── openai.clip-vit-base-patch32.onnx  # Modèle IA
```

### Packages NuGet

- `Microsoft.ML.OnnxRuntime` (1.23.2)
- `MetroModernUI` (1.4.0)
- `System.Numerics.Tensors` (10.0.2)
- `Costura.Fody` (6.0.0) - Embedding des DLLs

---

## Roadmap

### Fonctionnalités futures possibles
- [ ] Filtrage par seuil de similarité
- [ ] Export des résultats en CSV/JSON
- [ ] Comparaison avec un hash perceptuel (pHash, dHash)
- [ ] Regroupement visuel par clusters
- [ ] Mode batch pour plusieurs dossiers
- [ ] Détection de visages similaires
- [ ] Recherche d'image par similarité

---

## Auteur

Développé avec ❤️ en C# et Windows Forms

**Version actuelle** : 1.0.0

---

## Captures d'écran

*Interface principale avec liste des résultats*
- Boutons de sélection de dossier et d'analyse
- Progression en temps réel avec estimation
- Bouton d'annulation
- Tableau des résultats triés par similarité

*Prévisualisation des images*
- Affichage côte à côte des deux images
- Noms de fichiers et tailles
- Boutons de suppression
- Zoom au clic

---

## Support

Pour toute question ou problème, ouvrez une issue sur le dépôt GitHub.
