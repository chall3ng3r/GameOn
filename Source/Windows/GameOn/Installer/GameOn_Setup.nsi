; Script generated with the Venis Install Wizard

; Define your application name
!define APPNAME "GameOn for Unity"
!define APPNAMEANDVERSION "GameOn for Unity 0.9.1022"

; Main Install settings
Name "${APPNAMEANDVERSION}"
InstallDir "$PROGRAMFILES\GameOn"
InstallDirRegKey HKLM "Software\${APPNAME}" ""
OutFile "GameOn_0_9_setup.exe"

; Modern interface settings
!include "MUI.nsh"

!define MUI_ABORTWARNING
;!define MUI_FINISHPAGE_RUN "$INSTDIR\GameOn.exe"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

; Set languages (first is default language)
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_RESERVEFILE_LANGDLL

; Installer Icon
Icon "..\Graphics\Pixelkit-Gentle-Edges-Game-Controller.ico"

RequestExecutionLevel admin

Function .onInit
	# call UserInfo plugin to get user info.  The plugin puts the result in the stack
	UserInfo::getAccountType

	# pop the result from the stack into $0
	Pop $0

	# compare the result with the string "Admin" to see if the user is admin.
	# If match, jump 2 lines down (return).
	StrCmp $0 "Admin" +2

	# if there is not a match, print message and return
	MessageBox MB_OK "User $0 is not an administrator.$\r$\n\
			Installer may not have permissions to copy necessary files and installation may fail."
	Return
FunctionEnd

Section "GameOn for Unity" Section1

	SetShellVarContext all

	; Set Section properties
	SetOverwrite on

	; Set Section Files and Shortcuts
	SetOutPath "$INSTDIR\"
	File "..\Staging\GameOn.exe"
	File "..\Staging\GameOn.exe.config"
	File "..\Staging\AxInterop.UnityWebPlayerAXLib.dll"
	File "..\Staging\Interop.UnityWebPlayerAXLib.dll"
	
	CreateShortCut "$DESKTOP\GameOn.lnk" "$INSTDIR\GameOn.exe"
	CreateDirectory "$SMPROGRAMS\GameOn for Unity"
	CreateShortCut "$SMPROGRAMS\GameOn for Unity\GameOn.lnk" "$INSTDIR\GameOn.exe"
	CreateShortCut "$SMPROGRAMS\GameOn for Unity\Uninstall.lnk" "$INSTDIR\uninstall.exe"
	
SectionEnd

Section -FinishSection
	
	; Setup Registry
	WriteRegStr HKEY_CLASSES_ROOT "gameon" "" "URL:gameon"
	WriteRegStr HKEY_CLASSES_ROOT "gameon" "URL Protocol" ""
	WriteRegStr HKEY_CLASSES_ROOT "gameon" "DefaultIcon" "$INSTDIR\GameOn.exe,0"
	WriteRegStr HKEY_CLASSES_ROOT "gameon\shell\open\command" "" "$\"$INSTDIR\GameOn.exe$\" $\"%1$\""

	WriteRegStr HKLM "Software\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$INSTDIR\uninstall.exe"
	WriteUninstaller "$INSTDIR\uninstall.exe"

SectionEnd

; Modern install component descriptions
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	!insertmacro MUI_DESCRIPTION_TEXT ${Section1} ""
!insertmacro MUI_FUNCTION_DESCRIPTION_END

;Uninstall section
Section Uninstall

	SetShellVarContext all

	;Remove from registry...
	DeleteRegKey HKEY_CLASSES_ROOT "gameon"
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	DeleteRegKey HKLM "SOFTWARE\${APPNAME}"

	; Delete self
	Delete "$INSTDIR\uninstall.exe"

	; Delete Shortcuts
	Delete "$DESKTOP\GameOn.lnk"
	Delete "$SMPROGRAMS\GameOn for Unity\GameOn.lnk"
	Delete "$SMPROGRAMS\GameOn for Unity\Uninstall.lnk"

	; Clean up GameOn for Unity
	Delete "$INSTDIR\GameOn.exe"
	Delete "$INSTDIR\GameOn.exe.config"
	Delete "$INSTDIR\AxInterop.UnityWebPlayerAXLib.dll"
	Delete "$INSTDIR\Interop.UnityWebPlayerAXLib.dll"

	; Remove remaining directories
	RMDir "$SMPROGRAMS\GameOn for Unity"
	RMDir "$INSTDIR\"

SectionEnd

BrandingText "chall3ng3r.com"

; eof