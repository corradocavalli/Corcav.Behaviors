## Float.Corcav.Behaviors [![Test](https://github.com/gowithfloat/Float.Corcav.Behaviors/actions/workflows/test.yml/badge.svg)](https://github.com/gowithfloat/Float.Corcav.Behaviors/actions/workflows/test.yml) [![NuGet](https://img.shields.io/nuget/v/Float.Corcav.Behaviors)](https://www.nuget.org/packages/Float.Corcav.Behaviors/)

This project is the porting of core Blend behaviors infrastructure to Xamarin Forms Platform, you can read about initial version [here](http://bit.ly/xamarinbehaviors).

## Requirements

You must add a call to Corcav.Behaviors.Infrastructure.Init() to the FinishLaunching method within AppDelegate.cs of your iOS project.  See this [blog](http://codeworks.it/blog/?p=242) for more details.

## Updates

* version 3.0.0 updated to Xamarin Forms v 5.0.0.1874
  Modernized project structure
* version 2.3.7 updated to Xamarin Forms v 2.3.4.231
* version 2.3.5 updated to Xamarin Forms v 2.3.3.175
  Removed use of obsolete APIs

* version 2.3.4 updated to Xamarin Forms v 2.3.2.127
  Fixed missing profile 259 issue.

* version 2.3.2 updated to Xamarin Forms v 2.3.1.114
  EventToCommand now has an additional property: PassEventArgument (bool) when true will pass event argument to Command.
  
* version 2.2.0 updated to Xamarin Forms v 2.2.0.45 added support to UWP
* version 2.1.1 updated to Xamarin Forms v 1.4.4.6392
* version 2.0 RENAMED NAMESPACES TO PREVENT XAMARIN API CONFLICTS, added Unifed API sample and aligned to Xamarin Forms v 1.3.4

* NOTE for v1.3 users
This version replaces v1.3 available here https://github.com/corradocavalli/Xamarin.Forms.Behaviors/tree/Version1.3
In order to prevent conflicts with Xamarin API the namespace has been renamed, *this version will break your code*,  please align namespaces references.

## Building

This project can be built using [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) or [Cake](https://cakebuild.net/). It is recommended that you build this project by invoking the boostrap script:

    ./build.sh

There are a number of optional arguments that can be provided to the bootstrapper that will be parsed and passed on to Cake itself. See the [Cake build file](./build.cake) in order to identify all supported parameters.

    ./build.sh \
        --task=Build \
        --projectName=Float.Corcav.Behaviors \
        --configuration=Debug \
        --nugetUrl=https://nuget.org \
        --nugetToken=####

## License

All content in this repository is shared under an MIT license. See [license.md](./license.md) for details.
