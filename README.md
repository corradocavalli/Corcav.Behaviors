Behaviors plugin for Xamarin Forms
=======================

This project is the porting of core Blend behaviors infrastructure to Xamarin Forms Platform,
you can read about initial version here: http://bit.ly/xamarinbehaviors

Requirements
============

You must add a call to Corcav.Behaviors.Infrastructure.Init() to the FinishLaunching method within AppDelegate.cs of your iOS project.  See this [blog](http://codeworks.it/blog/?p=242)
for more details.

Updates
=======
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


Use Git repo for feedback and issues.

*License
Project is released under MIT license

The MIT License (MIT)

Copyright (c) 2013-2016 Maksim Volkau

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.