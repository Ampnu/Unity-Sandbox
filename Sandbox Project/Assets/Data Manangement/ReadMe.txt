Package Scope:
Component Locator Module

Namespace:
VRS.DataManagement.Content

Data Management Setup:

1. Place Data Mapper Script on desired gameobject in scene.
2. Copy JSON file to Resources/JSON or change path and/or filename in DataImporter.cs
3. Place 3D Model into Data Mapper. Make sure 3D Model as been tagged with PartID components. Use ModelTagger Tool to add PartID's;
4. After ContentDB has been intialize, use ContentQuery class to query DB for component data.
