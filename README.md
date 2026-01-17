# ImageDup - Détection de doublons d'images

Application Windows Forms .NET Framework 4.8.1 pour détecter les doublons d'images en utilisant l'IA (modèle ONNX CLIP).

## Fonctionnalités

- Compare deux images et calcule leur similarité sémantique (0-100%)
- Utilise le modèle CLIP (Contrastive Language-Image Pre-training) d'OpenAI
- Interface graphique simple et intuitive
- Détecte les doublons même avec des résolutions ou recadrages différents

## Prérequis

- Windows 7 ou supérieur
- .NET Framework 4.8.1

## Compilation

### Avec Visual Studio
1. Ouvrez `ImageDup.sln` dans Visual Studio
2. Cliquez sur "Générer" > "Générer la solution"
3. L'exécutable sera dans `bin\Debug\ImageDup.exe` ou `bin\Release\ImageDup.exe`

### En ligne de commande
```bash
msbuild ImageDup.csproj /p:Configuration=Release
```

## Utilisation

1. Lancez `ImageDup.exe`
2. Cliquez sur "Sélectionner Image 1" pour choisir la première image
3. Cliquez sur "Sélectionner Image 2" pour choisir la deuxième image
4. Cliquez sur "Comparer" pour calculer la similarité
5. Le score de similarité s'affiche en pourcentage :
   - **80-100%** (vert) : Images très similaires, probablement des doublons
   - **50-80%** (orange) : Images similaires avec des différences
   - **0-50%** (rouge) : Images différentes

## Formats d'images supportés

- JPEG (.jpg, .jpeg)
- PNG (.png)
- BMP (.bmp)
- GIF (.gif)

## Architecture technique

- **Frontend** : Windows Forms .NET Framework 4.8.1
- **Traitement d'images** : System.Drawing
- **Modèle IA** : Microsoft.ML.OnnxRuntime avec CLIP ViT-B/32
- **Tensors** : System.Numerics.Tensors

## Structure du projet

```
ImageDup/
├── ImageDup.csproj          # Fichier projet
├── Program.cs               # Point d'entrée
├── MainForm.cs              # Interface utilisateur
├── MainForm.Designer.cs     # Définition visuelle du formulaire
├── ImageComparisonService.cs # Logique de comparaison IA
├── Properties/              # Métadonnées et ressources
└── wwwroot/
    └── models/
        └── openai.clip-vit-base-patch32.onnx  # Modèle CLIP
```

## Comment ça marche

1. **Preprocessing** : Les images sont redimensionnées en 224x224 pixels et normalisées
2. **Embedding** : Le modèle CLIP génère un vecteur de caractéristiques pour chaque image
3. **Similarité cosinus** : Les vecteurs sont comparés pour calculer un score de 0 à 100%

## Dépendances NuGet

- Microsoft.ML.OnnxRuntime (1.16.3)
- System.Memory (4.5.5)
- System.Numerics.Tensors (8.0.0)

## Licence

Ce projet utilise le modèle CLIP d'OpenAI. Consultez la licence OpenAI pour plus d'informations.
