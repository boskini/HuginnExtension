
![Huginn](https://github.com/rafaelboschini/HuginnExtension/blob/master/HuginnExtension/Logo%20.png?raw=true)

# Huginn - Visual Studio Extension

This extension provides a easy way to configure commands to run in powershell when some document are changed in Visual Studio.

## 👩🏽‍💻 Install and Configure

First you need download and install Huginn Extension in your visual studio.
You can download at [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=RafaelBoschini.HuginnExtension2020) 💖

After installation, you must create a configuration file in root of your project folder to activate the ***Huginn Extension***.

📃 The name of config file must be `Huginn-config.json` and this file has to contains the structure data example below.

```
{
  "items": [
    {
      "ext": "html",
      "command":  "Copy-Item C:\Users\Boschini\index.html C:\Inetpub\wwwroot\VSExtension\web\index.html"
    },
    {
      "ext": "scss",
      "command":  "sass C:\Users\Boschini\style\style.scss C:\Inetpub\wwwroot\VSExtension\web\css\index.min.css"
    }
  ]
}
```

The property `ext` responsible to create an criteria to trigger commands when this criteria has answered.
The property `command`....is the command 😁

## 🤹 How to use

You can configure `ext` property to watches a entire folder or file, a piece of file path or by extension, this flexibility provides a lot of ways to solve your problem. 

**Let me show some examples:**

**By piece of string**
This example bellow will run the command `mycommand.ps1` when every document saved has **HuginnExt** in the file path.

⚠️ That example find a piece of string in full file path of changed document.

```
    {
      "ext": "HuginnExt",
      "command":  "mycommand.ps1"
    },
```
That command was triggered when I changed the file C:\Users\Boschini\Worspace\HuginnExt\web\style\style.scss

--------
**By file type**
This example will run every `.scss` document was saved, this is the way to watches a entire file type extension.
```
    {
      "ext": ".scss",
      "command":  "sass path1 path2"
    },
```

--------
**By specific file**
This example will run every `style.scss` was changed.
```
    {
      "ext": "style.scss",
      "command":  "sass path1 path2"
    },
```
🔰 License
----
![Its Free](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSLsKzPdVOwDVxikGynwZ522ALPrIa0FnUAA&usqp=CAU)


## 🧙🏻‍♂️ Contact Me

Rafael Boschini <rafaelboschini@gmail.com>
[My Linkedin](https://www.linkedin.com/in/rafael-boschini-5747311/) | [My Github](https://github.com/rafaelboschini)  | [My Stackoverflow Profile](https://pt.stackoverflow.com/users/34573/rboschini)

*Then I was fertilized and grew wise;  
From a word to a word I was led to a word,  
From a work to a work I was led to a work.*