using IfcToolbox.Core.Hierarchy;
using IfcToolbox.Tools.Configurations;
using IfcToolbox.Tools.Processors;
using Serilog;
using System.Collections.Generic;
using IfcToolbox.Examples.Utility;
using System;

namespace IfcToolbox.Examples.Samples
{
    public class IfcSplitterSample
    {
        public static void SplitByBuildingStorey(string filePath)
        {
            Log.Information($"IfcSplitter - Start");
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.LogDetail = true;
            config.SplitStrategy = SplitStrategy.ByBuildingStorey;
            var model = Xbim.Ifc.IfcStore.Open(filePath);
            var reader = HierarchyReader.GetSpatialHierarchy(model, "IfcBuildingStorey").Show(true);
            Console.WriteLine(reader);
            config.SelectedItems = new List<string> { };

            config.SelectedItems = new GetBuildingStoreyId().Regex(reader);
            SplitterProcessor.Process(filePath, config, true);
        }
    }
}
