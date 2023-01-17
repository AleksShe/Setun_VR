// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Alex_b/Alex_PBR_FD" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_AO_map ("AO",2D) = "white" {}
		_AO_pow ("AO POWER",Range(0,1)) = 1.0
		_MSmooth("MetalSmooth",2D) = "black" {}
		_Normal("Normal",2D) = "black" {}
		_Emiss_Map("Emiss map",2D) =  "white" {}
		_Emiss_channel("Emiss channel",2D) = "black" {}
	

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _AO_map;
		sampler2D _MSmooth;
		sampler2D _Normal;
		sampler2D _Emiss_Map;
		sampler2D _Emiss_channel;
		struct Input {
			float2 uv_MainTex;
			float2 uv_Normal;
			float2 uv_Emiss_channel;
		};
		half _AO_pow;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 em = tex2D(_Emiss_Map,IN.uv_MainTex);
			fixed4 emc = tex2D(_Emiss_channel,IN.uv_Emiss_channel);
			fixed4 ao = tex2D(_AO_map,IN.uv_MainTex);
			fixed4 ms = tex2D(_MSmooth,IN.uv_MainTex);
			fixed4 n = tex2D(_Normal,IN.uv_Normal);
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Occlusion = lerp(ao.r,1.0,_AO_pow);
			o.Albedo = c.rgb;
			o.Normal = UnpackNormal(n);
			// Metallic and smoothness come from slider variables
			o.Metallic = ms.r;
			o.Smoothness = ms.a;
			o.Alpha = c.a;
			half ec_r = lerp(1,0,clamp(sin(_Time.y*50.0),0.0,1.0));
			fixed ec_g = lerp(1,0,clamp(sin(_Time.y*20.0),0.0,1.0));
			fixed ec_b =lerp(1,0,clamp(sin(_Time.y*40.0),0.45,1.0));
			half clear_r = lerp(0.0,ec_r,emc.r);
			half clear_g = lerp(0.0,ec_g,emc.g);
			float clear_b = lerp(0.0,ec_b,emc.b);
			fixed4 g = fixed4(0,0,0,1);
			o.Emission = lerp(em.rgb,g.rgb,clear_b+clear_g+clear_r);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
