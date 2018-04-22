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



public sealed class SRResources {
    
    private SRResources() {
    }
    
    private const string _tsInternal = "1.3.2-Unity5";
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
    
    public sealed class SFX {
        
        private SFX() {
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> S_Hit01 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[0]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> S_Explo01 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[1]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> S_Hit02 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[2]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> S_Shoot01 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[3]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> S_Explo02 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[4]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("S_Hit01", "SFX/S_Hit01"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("S_Explo01", "SFX/S_Explo01"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("S_Hit02", "SFX/S_Hit02"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("S_Shoot01", "SFX/S_Shoot01"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("S_Explo02", "SFX/S_Explo02")});
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return __ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((__ts_internal_recursiveLookupCache != null)) {
                return __ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            __ts_internal_recursiveLookupCache = tmp;
            return __ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    public sealed class Prefabs {
        
        private Prefabs() {
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
        
        public sealed class Dynamic {
            
            private Dynamic() {
            }
            
            public static global::TypeSafe.PrefabResource BulletCharge01 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Impact {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Shield {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Explo01 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[3]));
                }
            }
            
            public static global::TypeSafe.PrefabResource BulletCharge02 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[4]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Bullet01 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[5]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Bullet02 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[6]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("BulletCharge01", "Prefabs/Dynamic/BulletCharge01"),
                        new global::TypeSafe.PrefabResource("Impact", "Prefabs/Dynamic/Impact"),
                        new global::TypeSafe.PrefabResource("Shield", "Prefabs/Dynamic/Shield"),
                        new global::TypeSafe.PrefabResource("Explo01", "Prefabs/Dynamic/Explo01"),
                        new global::TypeSafe.PrefabResource("BulletCharge02", "Prefabs/Dynamic/BulletCharge02"),
                        new global::TypeSafe.PrefabResource("Bullet01", "Prefabs/Dynamic/Bullet01"),
                        new global::TypeSafe.PrefabResource("Bullet02", "Prefabs/Dynamic/Bullet02")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Units {
            
            private Units() {
            }
            
            public static global::TypeSafe.PrefabResource Player {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Enemy01 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Friend01 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Obstacle01 {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[3]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("Player", "Prefabs/Units/Player"),
                        new global::TypeSafe.PrefabResource("Enemy01", "Prefabs/Units/Enemy01"),
                        new global::TypeSafe.PrefabResource("Friend01", "Prefabs/Units/Friend01"),
                        new global::TypeSafe.PrefabResource("Obstacle01", "Prefabs/Units/Obstacle01")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class UI {
            
            private UI() {
            }
            
            public static global::TypeSafe.PrefabResource GameOverScreen {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Canvas {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource StartScreen {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource BottomBar {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[3]));
                }
            }
            
            public static global::TypeSafe.PrefabResource TurnPhaseIndicator {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[4]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("GameOverScreen", "Prefabs/UI/GameOverScreen"),
                        new global::TypeSafe.PrefabResource("Canvas", "Prefabs/UI/Canvas"),
                        new global::TypeSafe.PrefabResource("StartScreen", "Prefabs/UI/StartScreen"),
                        new global::TypeSafe.PrefabResource("BottomBar", "Prefabs/UI/BottomBar"),
                        new global::TypeSafe.PrefabResource("TurnPhaseIndicator", "Prefabs/UI/TurnPhaseIndicator")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Environement {
            
            private Environement() {
            }
            
            public static global::TypeSafe.PrefabResource Grid {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource GridSet {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("Grid", "Prefabs/Environement/Grid"),
                        new global::TypeSafe.PrefabResource("GridSet", "Prefabs/Environement/GridSet")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return __ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((__ts_internal_recursiveLookupCache != null)) {
                return __ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            tmp.AddRange(Dynamic.GetContentsRecursive());
            tmp.AddRange(Units.GetContentsRecursive());
            tmp.AddRange(UI.GetContentsRecursive());
            tmp.AddRange(Environement.GetContentsRecursive());
            __ts_internal_recursiveLookupCache = tmp;
            return __ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    /// <summary>
    /// Return a list of all resources in this folder.
    /// This method has a very low performance cost, no need to cache the result.
    /// </summary>
    /// <returns>A list of resource objects in this folder.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
        return __ts_internal_resources;
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
    
    /// <summary>
    /// Return a list of all resources in this folder and all sub-folders.
    /// The result of this method is cached, so subsequent calls will have very low performance cost.
    /// </summary>
    /// <returns>A list of resource objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
        if ((__ts_internal_recursiveLookupCache != null)) {
            return __ts_internal_recursiveLookupCache;
        }
        global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
        tmp.AddRange(GetContents());
        tmp.AddRange(SFX.GetContentsRecursive());
        tmp.AddRange(Prefabs.GetContentsRecursive());
        __ts_internal_recursiveLookupCache = tmp;
        return __ts_internal_recursiveLookupCache;
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder.
    /// </summary>
    public static void UnloadAll() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder and subfolders.
    /// </summary>
    private void UnloadAllRecursive() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
    }
}
