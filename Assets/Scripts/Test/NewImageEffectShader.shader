Shader "Hidden/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Main Dimension Texture", 2D) = "white" {}
		_AlternateTex("Alternate Dimension Texture", 2D) = "white" {}
		_TransparencyTex("Transparency Texture", 2D) = "white" {}
		_CutOffValue("Cutoff Value", Range(0, 1)) = 0.5
		_BlurOffset("Blur Offset", Range(0, 1)) = 0.6
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			sampler2D _AlternateTex;
			sampler2D _TransparencyTex;
			float1 _CutOffValue;
			float1 _BlurOffset;
            half4 frag (v2f i) : SV_Target
            {

                //half4 col = tex2D(_MainTex, i.uv);
				half4 colTransparency = tex2D(_TransparencyTex, i.uv);
				half4 colMain = tex2D(_MainTex, i.uv);
				half4 colAlt = tex2D(_AlternateTex, i.uv);

				float4 dimension = smoothstep(_CutOffValue, _CutOffValue + _BlurOffset, colTransparency.w);
				dimension = clamp(dimension, 0, 1);

				return lerp(colMain, colAlt, dimension);

                //col.rgb = 1 - col.rgb;
                //return col;
            }
            ENDCG
        }
    }
}
