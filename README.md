# PLUTUS #

Plutus is an application that allows user to view, track and edit his incomes and outcomes.  
It's a desktop wallet with chart features and traceability of all events related to the money which user wishes to keep.

---

## Purpose ##

The goal of this project was to:

* Create the wallet-manager desktop application with desired features but as simple as possible
* Implement the project with exactly six design patterns:  
Two creational,  
Two structural,  
Two behavioral.

* Present the ability of WPF when it comes to rapid development and functionalities implementation.

---

## Patterns ##

As already mentioned this project implements exactly six design patterns, two of each group: structural, creational, behavioral.  
The trick in this implementation is to avoid an overengineering at all costs!  
Implementation and usage of each pattern should fit into the functionality, should make the implementation easier and should solve the problems.

Patterns used in this project are as follows:

| Name | Description (where/how it's used) |
|-|-|
| **MVVM** | The basic desgin pattern when it comes to WPF GUI application development. This structural pattern allows to divide the application into three layers similar to Model-View-Controller. But here, instead of just controller the connector between **M**odel and **V**iew is a **V**iew**M**odel. |
| **Facade** | Second structural design pattern which provides a simplified interface to a library, a framework, or any other complex set of classes. This pattern is used to gather all the ViewModels implemented in the project and introduce them together to the View as one `FacadeViewModel` |
| **Singleton** | Creational pattern used to force the implementation to have only one instance of the singleton class. In this application this pattern will be used to keep all the settings and constants related to user and his session |
| **Prototype** | This creational pattern is a way to easily create an object of class just by copying another object of this class. By implementing such behavior it's easy to make this cloning set the desired properties of new instance. In this project this pattern is used to create another dot on the wallet income/outcome chart. |
| **Observer** | Behavioral pattern which defines the subscription mechanism to notify objects about an event. In this project this pattern is used to fully implement the command mechanism for all the GUI controlls. |
| **Command** | Command is a built-in behavioral design pattern that converts requests or simple operations into objects. It's used by implementing the *ICommand* interface when creating the WPF application. |

---

## Technology ##

Tools and their versions used in this project are listed in the table below:

|      Name     | Version |
|:-------------:|:-------:|
|       C#      |   8.0   |
|   .NET Core   |   3.1   |
| Visual Studio |  16.5.4 |
|    OxyPlot    |  2.0.0  |

---

## Result ##
Once the project is finished and implementation completed, screens and download packages will start to appear in this section.  
Stay tuned!
