Shader "MaskJam2000/MaskPickupFill"
{
    Properties
    {
        _Fill ("fill", Range(0.0, 1.0)) = 0.5
        _Color("fill color", Color) = (.25, 1, .5, 1)
        _ColorEmpty("empty color", Color) = (0, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            
            float4 _Color;
            float4 _ColorEmpty;
            float _Fill;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float fill = clamp((_Fill - i.uv.x) * 128, 0, 1);
                fixed4 col = lerp(_ColorEmpty, _Color, fill) * 2;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
