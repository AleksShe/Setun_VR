// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Alex_b/Alex_Laptop_Display" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
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

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float2 pos = IN.uv_MainTex;
			float amnt = 0.0f;
			float nd = 0.0f;
			fixed4 cbuff = fixed4(0,0,0,0);
			for(float i =0.0f;i<10.0f;i++){
			nd = sin(3.93f*0.8f*pos.x+(i*0.2f+sin(+_Time)*20.8f)+_Time)*0.4f+0.1f+pos.x;
			nd *= sin(3.93f*0.8f*pos.y+(i*0.2f+sin(+_Time)*20.8f)+_Time)*0.4f+0.1f+pos.y;
			amnt = 0.5f/abs(nd-pos.y)*0.02f*5.0f/abs(nd-pos.x)*0.02f;
			cbuff +=fixed4(amnt,amnt*0.3f,amnt*pos.x,1.0f);
			}
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			float ms = 0.0;
			float mixh =sin(_Time.y/2.0);
			if(mixh>0.0)
			{
				ms=1.0;
			}else{
				ms=0.0;
			}
			fixed3 fin_color = lerp(cbuff.rgb,c.rgb,ms);
			o.Albedo = fin_color;//c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Emission = fin_color;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
