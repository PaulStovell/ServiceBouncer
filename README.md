As a developer building Windows Services, the workflow of constantly stopping and starting services can be a bit annoying, especially if your solution consists of multiple services. **ServiceBouncer** is a simple tool that helps to streamline this workflow. 

**Download Zip**: [ServiceBouncer.zip](https://github.com/PaulStovell/ServiceBouncer/releases)

**Download Octopus Nuget Package**: [ServiceBouncer.nupkg](https://github.com/PaulStovell/ServiceBouncer/releases)

The tool shows a data grid for the services, and their status. Since it's a grid, you can easily select multiple services. You can then start or stop them. You can also filter the services shown, so that you don't accidentally stop the wrong one. There's even a button to delete services you no longer need. 


![ServiceBouncer main window - stop, start, delete, filter & manage services](https://raw.githubusercontent.com/PaulStovell/ServiceBouncer/master/.images/MainWindow.png)

###### Usage:
  servicebouncer

###### Options:
  -m --machine  	        Machine to connect to. Defaults to local machine.
  
  -t --terminateMinutes	    Number of minutes of user inactivity until application terminates. Defaults to never.

Icons from https://icons8.com - [Color set](https://icons8.com/icon/new-icons/color)
