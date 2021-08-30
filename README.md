# Version-Management
Simple version management library that allows your applications to keep users up to date.

Version: 1.0

## How to use
You will need your own webserver to utilize this library.
Installation is simple. Add the .dll to your project like any other library. The .dll is found in the zip archive provided.

Also in this zip archive is the "VersionManagement.php" php script. You will need to add this to your webserver.

To set the version, you can directly modify the php file or you can call the SetVersion() function from a file that references it.

When in your .NET code, use VersionChecker.GetLatest("https://your-url-here.com/path-to-file.php?action=echo"); You will need to change the url.

## License
Copyright (c) 2021 Alex Potter

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
