KanColleViewer
--

This is a browser/tool of sorts to make playing KanColle easier.

KanColleViewer is primarily developed by [@Grabacr07](https://twitter.com/Grabacr07). This fork has improvements by [@Southrop113](https://twitter.com/southrop113).

### About the Project
The tool uses WPF's web browser control to display the game and FiddlerCore to capture communication data.
Obviously, the tool does not modify the information or send any new infromation to the KanColle servers at all.

#### Main Features
* An accurate real-time display for instant repair (buckets) and instant build (flamethrowers) items
* An accurate real-time display for the number of shipgirls and equipments you currently have
* Summary of all available fleets and the shipgirls in them
* Repair and construction dock status and notifications for when the timers end
* Expedition status and notifications for when the timers end
* Screenshots
* Mute audio

* English support

#### Planned Features
* A lot

### System Requirements
* Windows 7 or higher
* .NET Framework 4.5

While the program does run on Windows 7, popup notifications for Expeditions and Construction/Repair timers will cause the program to crash. This is on the list of things to be fixed.
Not everything has been tested on Windows 7, so please report any issues you encounter.

### Build Instructions
NOTE: Windows 8 is required to build it

1. Download the files
2. Download and install Visual Studio (any version should work)
3. Open the .sln solution
4. Go to Build > Build solution
5. The resultant executable is located under ``Grabacr07.KanColleViewer/bin/Debug/KanColleViewer.exe``

Note: this version is specifically optimised for usage with the API url.
When you start the program, there is a navigation bar that you can enter your URL into,
but if you want to keep using the program, I suggest you edit ``KanColleViewer.exe.config``
and put your API url in there under the KanColleURL setting. Make sure you change the ``&`` to ``&amp;``
so the URL looks something like this:
``` xml
<setting name="KanColleUrl" serializeAs="String">
  <value>http://server.ip.goes.here/kcs/mainD2.swf?api_token=yourapikeygoeshere&amp;api_starttime=sometimestamphere</value>
</setting>
```
