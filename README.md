# simple-recursion-fractals
Creates simple fractals based on recursion. This code is for illustrative and learning purposes only.

## Setup mono
Follow the instructions here to install mono:
```
http://www.mono-project.com/docs/getting-started/install/linux/
```

Do not forget to install also these other packages:
```
sudo apt-get install mono-mcs
sudo apt-get install mono-devel
```

## How to compile and run
Compile:
```
mcs simpleRecursionFractals.cs fractalFunctions.cs -pkg:dotnet
```
Run:
```
mono simpleRecursionFractals.exe
```

## Add your own fractal implementation
1) Add your recursive function in the file fractalFunctions.cs as a method of the class Fractals. Note that you have to give an object of the class Graphics to perform some painting, the other parameters are up to you depending on your fractal, just don't forget the stopping rule.

2) In the file monoSimpleRecursionFractals.cs, do the following:
 * Register your function in the MainForm class of the project  For generality, in the method MainForm(), add in the dictionary fractalNames the name of the method of your fractal and the name to show in the comboBox, example:
´´´
fractalNames.Add("methodNameInClassFractals", "method-Name-For-ComboBox");
´´´
 * In the method Button_Click, link the selection of the comboBox to the fractal method by adding a call to the corresponding fractal function. Example:
 ´´´
 if (cb.SelectedItem.ToString() == fractalNames["methodNameInClassFractals"]) {
     fractal.methodNameInClassFractals(gp, 100, 100, ratio);
 }
 ´´´
