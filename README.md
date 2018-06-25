# fk - thefcuk
Fix command line spelling errors like it's 1999.

![demo](https://i.imgur.com/ZA3apcs.gif?1)

# Installation Instructions

Add the directory fk.exe is located to your [path](https://www.howtogeek.com/118594/how-to-edit-your-system-path-for-easy-command-line-access), then put the following lines in your .bashrc file:

```
shopt -s histappend
PROMPT_COMMAND="history -a;$PROMPT_COMMAND"
```

# Why?
This project was inspired by [The Fuck](https://github.com/nvbn/thefuck).

Initially I tried to just use TheFuck but I antivirus on my machine was not happy with the name of the application it kept complaining that a HIGH severity malware is found, we could not clean up a threat.

Hence I decided to writeup the one in C#.

