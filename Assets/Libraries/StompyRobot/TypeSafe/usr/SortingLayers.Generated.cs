// ------------------------------------------------------------------------------
//  _______   _____ ___ ___   _   ___ ___ 
// |_   _\ \ / / _ \ __/ __| /_\ | __| __|
//   | |  \ V /|  _/ _|\__ \/ _ \| _|| _| 
//   |_|   |_| |_| |___|___/_/ \_\_| |___|
// 
// This file has been generated automatically by TypeSafe.
// Any changes to this file may be lost when it is regenerated.
// https://www.stompyrobot.uk/tools/typesafe
// 
// TypeSafe Version: 1.3.2-Unity5
// 
// ------------------------------------------------------------------------------



public sealed class SRSortingLayers {
    
    private SRSortingLayers() {
    }
    
    private const string _tsInternal = "1.3.2-Unity5";
    
    public static global::TypeSafe.SortingLayer Background {
        get {
            return __all[0];
        }
    }
    
    public static global::TypeSafe.SortingLayer Bullets {
        get {
            return __all[1];
        }
    }
    
    public static global::TypeSafe.SortingLayer Units {
        get {
            return __all[2];
        }
    }
    
    public static global::TypeSafe.SortingLayer Default {
        get {
            return __all[3];
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.SortingLayer> __all = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.SortingLayer>(new global::TypeSafe.SortingLayer[] {
                new global::TypeSafe.SortingLayer("Background", 4446773),
                new global::TypeSafe.SortingLayer("Bullets", 824697895),
                new global::TypeSafe.SortingLayer("Units", 1393196931),
                new global::TypeSafe.SortingLayer("Default", 0)});
    
    public static global::System.Collections.Generic.IList<global::TypeSafe.SortingLayer> All {
        get {
            return __all;
        }
    }
}
