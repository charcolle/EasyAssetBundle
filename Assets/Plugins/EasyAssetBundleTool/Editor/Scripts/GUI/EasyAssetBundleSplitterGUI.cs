﻿using UnityEngine;
using UnityEditor;
using System;

using SplitterState = charcolle.Utility.EasyAssetBundle.v1.SplitterState;

namespace charcolle.Utility.EasyAssetBundle.v1 {

    //
    // from UNIBOOK5 by ando http://www.unity-bu.com/2016/06/unibook-5-info.html
    //
    internal class SplitterGUI {

        static Type splitterGUILayoutType;
        object splitterGUILayout;

        [InitializeOnLoadMethod]
        static void Init() {
            splitterGUILayoutType = Type.GetType( "UnityEditor.SplitterGUILayout,UnityEditor" );
        }

        public static void BeginHorizontalSplit( SplitterState state, GUIStyle style, params GUILayoutOption[] options ) {
            DoMethod( "BeginHorizontalSplit", new Type[] {
            SplitterState.splitterStateType,
            typeof(GUIStyle),
            typeof(GUILayoutOption[])
        }, null, new object[] { state.GetState(), style, options } );
        }

        public static void BeginHorizontalSplit( SplitterState state, params GUILayoutOption[] options ) {
            DoMethod( "BeginHorizontalSplit", new Type[] {
            SplitterState.splitterStateType,
            typeof(GUILayoutOption[])
        }, null, new object[] { state.GetState(), options } );
        }

        public static void EndHorizontalSplit() {
            DoMethod( "EndHorizontalSplit", null, new object[ 0 ] );
        }

        private static object DoMethod( string name, object obj, object[] args ) {
            return DoMethod( name, new Type[ 0 ], obj, args );
        }

        private static object DoMethod( string name, Type[] types, object obj, object[] args ) {
            if( types.Length != 0 )
                return splitterGUILayoutType.GetMethod( name, types ).Invoke( obj, args );
            else
                return splitterGUILayoutType.GetMethod( name ).Invoke( obj, args );
        }
    }

    public class SplitterState {
        public static Type splitterStateType {
            get {
                return Type.GetType( "UnityEditor.SplitterState,UnityEditor" );
            }
        }

        object splitterState;

        [InitializeOnLoadMethod]
        static void Init() {
        }

        public object GetState() {
            return splitterState;
        }

        public SplitterState( float[] relativeSizes, int[] minSizes, int[] maxSizes, int splitSize ) {
            splitterState = Activator.CreateInstance( splitterStateType, new object[] {
            relativeSizes,
            minSizes,
            maxSizes,
            splitSize
        } );
        }

        public SplitterState( float[] relativeSizes, int[] minSizes, int[] maxSizes ) {
            splitterState = Activator.CreateInstance( splitterStateType, new object[] {
            relativeSizes,
            minSizes,
            maxSizes
        } );
        }

        public SplitterState( int[] realSizes, int[] minSizes, int[] maxSizes ) {
            splitterState = Activator.CreateInstance( splitterStateType, new object[] {
            minSizes,
            maxSizes
        } );
        }

        public SplitterState( params float[] relativeSizes ) {
            splitterState = Activator.CreateInstance( splitterStateType, new object[] {
            relativeSizes
        } );

        }
    }
}