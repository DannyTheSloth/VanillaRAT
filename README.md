## VanillaRat - Advanced Remote Administration Tool
### Description:
VanillaRat is an advanced remote administration tool coded in C#. VanillaRat uses the Telepathy TCP networking library, dnlib module reading and writing library, and Costura.Fody dll embedding library.

###Features:
- Remote Desktop Viewer (Very buggy and low performance at the moment)
- File Browser (Including downloading, uploading, and file opening)
- Process Manager
- Computer Information 
- Hardware Usage Information (CPU usage, disk usage, available ram)
- Message Box Sender 
- Website Opener 
- Application Permission Raiser (Normal -> Admin)
- Clipboard Text (Copied text)

###TODO:
- Code cleanup and commenting
- Add a keylogger
- Add password recovery
- Add a remote shell 
- Add options for installation 

### How To Use:
**Release:**
1. Download the latest release from the releases section 
2. Ensure a designated port is opened, the default port is 1604
3. A DNS address is required, you may get one for free at https://no-ip.com/
4. Run the VanillaRat.exe and have fun! 

Note: If you accidentally run VanillaRatStub.exe, you can end the process by opening task manager and killing VanillaRatStub.

**Debug:**

1. Open the solution file
2. Ensure dnlib is installed on the VanillaRat project
3. Ensure Costura.Fody, and Telepathy is installed on both the VanillaRat project and the VanillaRatStub project
4. Build the VanillaRatStub project.
5. Build the VanillaRat project, open the bin of the VanillaRatStub project, and drag the VanillaRatStub.exe file into the bin of the VanillaRat project.
6. Run VanillaRat.exe and have fun! 
7. If any modification is made to VanillaRat or VanillaRatStub steps 4-5 need to be repeated. 

##Important Disclaimer:

**I am in no way responsible for any malicious actions that you may make using this software. Please take note that this application was designed for educational purposes and should never be used malicously.**
