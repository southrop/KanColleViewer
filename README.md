KanColleViewer
--

This is a browser/tool of sorts to make playing KanColle easier.

KanColleViewer is primarily developed by [@Grabacr07](https://twitter.com/Grabacr07). This fork has improvements by [@southrop113](https://twitter.com/southrop113).

### About the Project
KCV uses WPF's web browser control to display the game and FiddlerCore to capture communication data.
The tool does not modify the information or send any new infromation to the KanColle servers in any way.

#### Main Features
* An accurate real-time display for instant repair (buckets) and instant build (flamethrowers) items
* An accurate real-time display for the number of shipgirls and equipments you currently have
* Summary of all available fleets and the shipgirls in them
* Repair and construction dock status and notifications for when the timers end
* Expedition status and notifications for when the timers end
* Screenshots (does not work for API URL)
* Mute audio
* English support

#### Planned Features
* A lot

### System Requirements
* Windows 7 or higher
* .NET Framework 4.5

The program will run fine on Windows 7, but popup (toast) notifications for Expeditions and Construction/Repair timers make use of Windows 8's notification centre, and as such will not work. Please report any other problems encountered.

### Build Instructions
NOTE: Windows 8 is required to build it

1. Download the files
2. Download and install Visual Studio (any version should work)
3. Open the .sln solution
4. Go to Build > Build solution
5. The resultant executable is located in ``Grabacr07.KanColleViewer/bin/``

### Usage Instructions
Note: this version is specifically optimised for usage with the API URL.

When you start the program, there is a navigation bar that you can enter your URL into,
but if you want to keep using the program, I suggest you edit ``KanColleViewer.exe.config``
and put your API URL in there under the ``KanColleUrl`` setting. Make sure you change the ``&`` to ``&amp;``
so the URL looks something like this:
``` xml
<setting name="KanColleUrl" serializeAs="String">
  <value>http://server.ip.goes.here/kcs/mainD2.swf?api_token=yourapikeygoeshere&amp;api_starttime=sometimestamphere</value>
</setting>
```

After starting up the program, you can change the language by going to Settings and then selecting one of the radio button options.