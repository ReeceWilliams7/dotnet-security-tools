using System;
using System.Collections.Generic;
using System.IO;

using CommandLine;

using RW7.DotNetSecurityTools.Core;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public class Options
    {
        public Options()
        {
            Directory = Path.Combine(Path.GetTempPath(), DateTime.Now.Ticks.ToString());
        }

        [Option(
            't',
            "output-types",
            Default = new OutputType[] { OutputType.Console },
            Separator = ',',
            HelpText = "Where to direct the output to (multiple can be specified). Supported - console, file")]
        public IEnumerable<OutputType> OutputTypes { get; set; }

        [Option(
            'd',
            "directory",
            HelpText = "The directory path to output the files to, if 'file' selected as an output type. Defaults to a new folder on the users temp path if not specified.")]
        public string Directory { get; set; }

        [Option(
            'b', 
            "output-base64", 
            Default = false,
            HelpText = "Output JWK as Base64 Encoded string")]
        public bool OutputBase64 { get;set; }

        [Option(
            'r',
            "output-rsa-keys",
            Default = false,
            HelpText = "Output RSA Public and Private Keys")]
        public bool OutputRsaKeys { get; set; }
    }
}