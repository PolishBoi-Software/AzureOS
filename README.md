<div align="center">
    <img src="Images/PBOS_Logo.png">
</div>

> [!warning]
> PBOS is currently a **work in progress**, meaning it can or **will** break.<br>If you encounter any issues with the OS, please create a GitHub issue.<br>**Contributors are welcome!**

**PBOS** is an operating system developed in C# using CosmosOS.

# Features
- FAT32 file system **(UNSTABLE ON PHYSICAL HARDWARE)**
- A basic user system
- A basic shell
- Basic shell commands
- A desktop environment

# Running
- Install CosmosOS
- Download VMware Player
- `git clone` this repository (If you want to use the non-stable versions, currently there's no release)
- Run `dotnet build` (if you cloned the repository)
- Open VMware Player
- Create a new virtual machine and attach the ISO as the main disk image (Make sure to give it a hard disk image (Must be IDE!), about 256 MB should be good enough)
- Run it

# TODO
- Use GrapeGL instead of standard CGS [ ]
- Add more apps [ ]
- Make the DE better (GrapeGL will actually help) [ ]
- Switch to PNG (GrapeGL has native support) [ ]