﻿using Juniansoft.AutoKams.Services;
using System;
using System.IO;
using WixSharp;

namespace AutoKams.Setup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string TargetFramework = "net462";
            const string ProgramFilesDir = "%ProgramFiles%";
            const string ProgramMenuDir = "%ProgramMenu%";
            const string InstallDir = "[INSTALLDIR]";

            var assembly = new AssemblyService(typeof(AssemblyService).Assembly);

            var project = new Project(
                name: $"{assembly.Name}",
                new Dir(
                    targetPath: Path.Combine(
                        ProgramFilesDir,
                        assembly.Company,
                        assembly.Product),
                    new Files(
                        sourcePath: Path.Combine(
                            "..",
                            $"{assembly.Name}",
                            "bin",
                            assembly.Configuration,
                            TargetFramework,
                            "*.*"),
                        filter: f => !f.EndsWith(".obj"))
                    {
                    },
                    new ExeFileShortcut(
                        name: $"Uninstall {assembly.Product}",
                        target: "[System64Folder]msiexec.exe",
                        arguments: "/x [ProductCode]")
                ),
                new Dir(
                    targetPath: Path.Combine(
                        ProgramMenuDir,
                        assembly.Company,
                        assembly.Product),
                    new ExeFileShortcut(
                        name: $"{assembly.Product}",
                        target: Path.Combine(InstallDir, $"{assembly.Name}.exe"),
                        arguments: "")
                    {
                        WorkingDirectory = InstallDir
                    }
                    /*,
                    new ExeFileShortcut(
                        name: $"Uninstall {assembly.Product}",
                        target: "[System64Folder]msiexec.exe",
                        arguments: "/x [ProductCode]"
                    )*/
                ),
                new EnvironmentVariable("Path", InstallDir)
                {
                    Id = "Path_INSTALLDIR",
                    Action = EnvVarAction.set,
                    Part = EnvVarPart.last,
                    Permanent = false,
                    System = true,
                })
            {
                // DO NOT Change, should be {158c8a9f-9310-4f45-b404-99fa0785d7f0}
                // Same with UpgradeCode
                GUID = new Guid("158c8a9f-9310-4f45-b404-99fa0785d7f0"),
                Name = assembly.Product,
                Version = assembly.Version,
                MajorUpgradeStrategy = MajorUpgradeStrategy.Default,

            };

            project.Name = $"{assembly.Product} - v{assembly.Version.ToString(3)}";
            project.ControlPanelInfo.ProductIcon = Path.Combine(
                            "..",
                            "..",
                            "resources",
                            "Favicon.ico");

            project.MajorUpgradeStrategy.RemoveExistingProductAfter = Step.InstallInitialize;
            project.LicenceFile = Path.Combine(".", "LICENSE.rtf");
            project.ResolveWildCards(pruneEmptyDirectories: true)
                    .FindFirstFile($"{assembly.Name}.exe")
                    .Shortcuts = new[]
                    {
                    new FileShortcut($"{assembly.Name}.exe", "%Desktop%")
                    };

            Compiler.PreserveTempFiles = true;
            Compiler.EmitRelativePaths = false;

            project
                .BuildMsi(path: Path.Combine(
                    "wix",
                    assembly.Configuration,
                    TargetFramework,
                    $"{assembly.Product.Replace(" ", "")}-v{assembly.Version.ToString(3)}.msi"));

        }
        
    }
}