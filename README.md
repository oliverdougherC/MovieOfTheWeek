# Jellyfin Movie of the Week Plugin

A Jellyfin plugin that allows administrators to feature a "Movie of the Week" on the home screen.

## Features
- Select any movie from your library to feature
- Optional glow effect around the featured movie
- Prominent display on the home screen
- Easy configuration through Jellyfin's plugin settings

## Installation
1. In Jellyfin, go to Dashboard -> Plugins -> Repositories
2. Add this repository: `https://github.com/oliverdougherC/MovieOfTheWeek`
3. Go to Catalog
4. Find "Movie of the Week" and install it
5. Restart Jellyfin

## Configuration
1. Go to Dashboard -> Plugins -> Movie of the Week
2. Select a movie from the dropdown list
3. Toggle the glow effect if desired
4. Save your changes

## Build & Develop
1. Clone this repository
2. Ensure you have .NET 6.0 SDK installed
3. Build with `dotnet build`
4. The compiled dll can be found in `bin/Debug/net6.0`

## License
MIT License - See LICENSE file for details 