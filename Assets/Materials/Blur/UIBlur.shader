Shader "Custom/UIBlur"
{
 Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0.0, 10.0)) = 1.0
        _Alpha ("Alpha", Range(0.0, 1.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BlurSize;
            float _Alpha;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                half4 color = half4(0, 0, 0, 0);

                for (float x = -1.0; x <= 1.0; x++)
                {
                    for (float y = -1.0; y <= 1.0; y++)
                    {
                        half4 sample = tex2D(_MainTex, uv + float2(x, y) * _BlurSize * 0.003);
                        color.rgb += sample.rgb * sample.a;
                        color.a += sample.a;
                    }
                }
                color.rgb /= (color.a + 0.00001);  // Предотвращение деления на 0
                color.a /= 9.0; // Усреднение альфа-канала
                
                color.a *= _Alpha; // Применение пользовательского альфа-значения
                
                return color;
            }
            ENDCG
        }
    }
}
