# Accent CS
Windows 10 introduced a system-wide accent color system that automatically applies
a custom color to many parts of the UI including third-party apps. Unfortunately, only
apps made for the Universal Windows Platform benefit from this feature while desktop apps
are stuck with the same color scheme since Vista.

Accent CS is a portable program for Windows 10 that applies your accent color to 
some UI elements in desktop apps by updating *System Colors* (i.e. the theme colors used by desktop apps) 
based on your accent color. These changes are usually subtle, but they contribute in 
reducing the disparities between the classic desktop environment and Universal apps.

## How it works
The *synchronization* process that Accent Color Synchronizer accomplishes consists of obtaining
your current accent color (the one defined in the Personalization|Colors page of the Settings app)
and applying the same color to some System Colors. When the accent color is changed, the process
must be repeated in order to keep the system colors the same as your accent color.

## License
This program is published under the MIT license.
