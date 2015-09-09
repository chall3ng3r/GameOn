# GameOn
GameOn is an Open Source solution to playing Unity3D games outside the browser, with a-click, and still keeping the ```.unity3d``` file hosted on developer's server. Perfect for indie developers and game portals.

There was this small conversation on Twitter about a month ago, and I immediately got an idea.
![Twitter Ref](https://github.com/chall3ng3r/GameOn/blob/master/Media/twitter_ref.png?raw=true)

So, it took me couple of nights to make and polish (a bit) the GameOn application. Currently its only for Windows, and I am planning for MacOS and Linux versions with help from Unity3D developer community. If you want to contribute, you're most welcome :)

# How It Works?
The solution is that end-user install this tiny GameOn application on PC, the concept it just like Steam. This will handle the click from browser and start the game in an new Windows application. 

Installing GameOn is one-time process, afterwards, users can just click on website which have GameOn enabled link to start the game. 

GameOn resigters itself as ```gameon://``` URL scheme handler when installed. There's also a wrapper Windows application which is launched when user clicks GameOn enabled links. This application is just holds Unity Web Player ActiveX control, and it parses the clicked URL, formats it, and passes on to Unity Web Player. 

# For Developers
Adding GameOn to your website or portal is pretty simple.

Before you made link to a page with embeded Unity Web Player like:
```
<a href="http://website.com/game_demo.html">Play Game</a>
```
For GameOn, you simply make links like:
```
<a href="gameon://website.com/game_demo.unity3d?640,460">Play Game</a>
```

The important things to note:
- Provide absolute URL to your ```.unity3d``` file, replacing ```http``` with ```gameon```
- Pass ```with,height``` as querysting with the URL, for player window size

That's it!
