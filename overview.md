# Huginn Visual Studio Extension

This extension helps to run powershell commands after save document.

## How to use

First you need have install HuginnExtension and after that you need to create `Huginn-config.json` in root folder of you project.


Inside Huginn-config.json, you configure script and criteria.

Example: 

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

The property "ext" means whorever text inside this field will be finded in current path, for example:

Path: C:\Users\Boschini\Worspace\HuginnExt\web\style\style.scss

This example will run every document saved forward HuginnExt folder recursively.
```
    {
      "ext": "HuginnExt",
      "command":  "mycommand.ps1"
    },
```

This example will run every scss document was saved.
```
    {
      "ext": "scss",
      "command":  "sass path1 path2"
    },
```


This example will run every style.scss was changed.
```
    {
      "ext": "style.scss",
      "command":  "sass path1 path2"
    },
```

License
----
MIT

**Free Software**

Then I was fertilized and grew wise;  
From a word to a word I was led to a word,  
From a work to a work I was led to a work.