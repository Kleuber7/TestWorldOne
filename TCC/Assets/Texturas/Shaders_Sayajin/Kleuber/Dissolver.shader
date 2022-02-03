Shader "Custom/Dissolver"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    //_NormalTex("Normal map(RGB)", 2D) = "bump"{}
    //_MetalText("Metallic map (RGB)", 2D) = "black" {}
   // _RoughnessTex("Roughness map (RGB)", 2D) = "black" {}
   // _EmissionTex("Emission map (RGB", 2D) = "black" {}
    _DissolverMaskTex("Dissolver Mask (RGB", 2D) = "black" {}
     _DissolverController("Dissolver Controler", Range(0,1)) = 0.0
    }
        SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:blend

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
    // sampler2D _NormalTex;
    // sampler2D _MetalText;
    // sampler2D _RoughnessTex;
    // sampler2D _EmissionTex;
     sampler2D _DissolverMaskTex;

     struct Input
     {
         float2 uv_MainTex;
     };

     // half _Glossiness;
     // half _Metallic;
      half _DissolverController;
      fixed4 _Color;


      // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
      // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
      // #pragma instancing_options assumeuniformscaling
      UNITY_INSTANCING_BUFFER_START(Props)
          // put more per-instance properties here
      UNITY_INSTANCING_BUFFER_END(Props)

      void surf(Input IN, inout SurfaceOutputStandard o)
      {
          // Albedo comes from a texture tinted by color
          fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
          //fixed4 normalMap = tex2D(_NormalTex, IN.uv_MainTex);
          //fixed4 metallicMap = tex2D(_MetalText, IN.uv_MainTex);
         // fixed4 roughnessMap = tex2D(_RoughnessTex, IN.uv_MainTex);
         // fixed4 emissionMap = tex2D(_EmissionTex, IN.uv_MainTex);
          fixed4 dissolverMap = tex2D(_DissolverMaskTex, IN.uv_MainTex);


          o.Albedo = baseColor.rgb * _Color.rgb;
          // Metallic and smoothness come from slider variables
         // o.Normal = normalMap;
          //o.Metallic = metallicMap.r;
         // float smothness = (1.0 - roughnessMap.r);
          //o.Smoothness = smothness;
          //o.Emission = emissionMap;
          o.Alpha = (_DissolverController < dissolverMap.r) ? 0.0 : 1.0;
      }
      ENDCG
    }
        FallBack "Diffuse"
}
