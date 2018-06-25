# fk - git the fuck
Fix command line spelling errors.

![demo](https://i.imgur.com/ZA3apcs.gif?1)

# Why?
This project was inspired by [The Fuck](https://github.com/nvbn/thefuck).

Initially I tried to use TheFuck but the antivirus on my machine was not happy with the name of the application. It kept complaining that a HIGH severity malware is found, we could not clean up a threat. Hence gave a try to writeup the one in C#.

# Installation Instructions

* Add the directory containing fk.exe to your [path](https://www.howtogeek.com/118594/how-to-edit-your-system-path-for-easy-command-line-access)
* Put the following lines in your .bashrc file to preserve bash history in multiple terminal windows:

```
shopt -s histappend
PROMPT_COMMAND="history -a;$PROMPT_COMMAND"
```