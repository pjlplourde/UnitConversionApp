# Unit Conversion App

A Windows Application to convert between metric, U.S., Imperial, and other units.

## Description

This is a Windows Presentation Foundation Application targeting .NET 5.0 created in Visual Studio 2019. The application consists of the WPF User Interface with one window. That window will have a dropdown to select the type of conversion ("dimension" to scientists), a text box to enter the value to be converted, a dropdown to select the units from which the conversion is to be done, and another dropdown to select the units to which the conversion is to be done. A button will then execute the conversion, and a text block will display the result.

There is also a Class Library, again targeting .NET 5.0, which will have the logic for the conversions, as well as store the conversion factors. The library, when doing the calculations, will need to track the number of significant digits or decimal places (as applicable, i.e. multiplication and division preserve significant digits while addition and substraction preserve decimal places) of the input, as well as that of applied conversion factors (some of which will be exact, others of which will have an uncertainty).

## Getting Started

### Dependencies

-    This project is being built on an x64-based PC using an Intel® Core™ i7-8700 CPU @ 3.20GHz running Windows 10 Pro Build 19044.

-    This project assumes a machine running .NET 5.

### installing

-    Installation instructions will be published after the first release build (v. 1.0.0.0) is released.

### Executing program

-    Instructions on how to execute the program will be published after the first release build (v. 1.0.0.0) is released.

## Help

-    Help documentation will be published after the first release build (v. 1.0.0.0) is released.

## Authors

Pierre Plourde [@pierre_plourde](https://twitter.com/pierre_plourde) - pierre@spartancsharp.net

See also the list of [contributors](https://github.com/pjlplourde/UnitConversionApp/contributors) who participated in this project.

## Version History

-    0.0.0.3
     -    Updated Assembly and File versions in Project files
-    0.0.0.2
     -    Updated README.md file in Visual Studio Code
-    0.0.0.1
     -    Initial Code Commit (Visual Studio Project Scaffolding)
-    0.0.0.0
     -    Initial commit

## Roadmap

-    [] Initial version will be a Minimum Viable Product that will allow the following conversions:
     -    [] In Length: to/from any of the following: metres, centimetres, miles, yards, feet, inches
     -    [] In Mass: to/from any of the following: kilograms, grams, pounds (technically pound-equivalents at standard Earth gravity), ounces, slugs (the _real_ unit of mass in the English system).
     -    [] In Temperature: to/from any of the following: degrees Celsius, degrees Fahrenheit, Kelvin.
-    [] The first major feature upgrade will extend the functionality to other conversion types (dimensions): time, electric current, amount of substance, luminous intensity, area, volume, speed, velocity, acceleration, wave number, density/mass density, specific volume, current density, magnetic field strength, concentration (of amount of substance), luminance, and refractive index.
-    [] The second major feature upgrade will extend the available units for conversion in each of the conversion types.

See the [open issues](https://github.com/pjlplourde/UnitConversionApp/issues) for a full list of proposed features (and known issues).

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.

## Contact

Pierre Plourde - [@pierre_plourde](https://twitter.com/pierre_plourde) - pierre@spartancsharp.net

Project Link: https://github.com/pjlplourde/UnitConversionApp

## Acknowledgments

Inspiration, code snippets, etc.

-    [awesome-readme](https://github.com/matiassingers/awesome-readme)
-    [PurpleBooth](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2)
-    [dbader](https://github.com/dbader/readme-template)
-    [zenorocha](https://gist.github.com/zenorocha/4526327)
-    [fvcproductions](https://gist.github.com/fvcproductions/1bfc2d4aecb01a834b46)
