Hotkey Pop up app 
By: Dima Levshukov

This app is meant to be used to mess with someone who does not know the app is ruinning on thier pc. It only works on Windows.

This app is a C sharp application that when running will make a large message pop up across the users entire primary monitor. 
The default message for the app simply says "Boo!", and it is triggered when any keyboard key is pressed.

This message can easily be changed be editing the PopupForm.cs and editing line 23 with it says "Boo!".
What key is used to trigger the pop up can also be changed in the MainForm.cs but is a bit harder to do, just use ChatGPT if inexperienced with code.

!! If making changes... Be careful to not make the apps tigger EVERY user input or pc can become unusable until turned off to close application. !!


HOW TO USE

To run the dotnet Microsoft tool will need to be installed. If not already on pc it can be found here:
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.411-windows-x64-installer

Then to use the app you need to download the zip file(editPopUpApp.zip) for the app(which already contains all the files in the repository). Then run the bat file (build_fresh.bat) which will create the app in Where_The_Zip_Was_Extracted\HotkeyPopUp\bin\Release\net6.0-windows\win-x64\publish\(there will be a folder with the name of the date)
Just run the HotKeyPopUp.exe file in that folder.

If you want to make any changes to the app you can edit the files. Then run the build_fresh.bat again which will create a new app for you with the changes.

After making any changed you like run the build_fresh.bat which will create a new app with your changes, it will be located in
Where_The_Zip_Was_Extracted\HotkeyPopUp\bin\Release\net6.0-windows\win-x64\publish
Inside of publish is a new folder that will just be named the date of when you ran the bat file, inside this folder you will find your new .exe file which can now be copied and removed from the rest of mess of folders and ran on its own.



HOW TO TURN OFF

The easiest way to turn off is to use your mouse right click on the windows task bar and open task manager. Then scroll down and find the app name and end that task.

If you made edits to the app and installed the build_fresh.bat, running this will also terminal any existing running versions of the app.





P.S. if you are experienced with coding and chose to make any edits to the app I recommend making a hot key to terminate the app running, I just couldn't think of a good key that someone wouldn't pressed in a panic on their keyboard and end the prank.
