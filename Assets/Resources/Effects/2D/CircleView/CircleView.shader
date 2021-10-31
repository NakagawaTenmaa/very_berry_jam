Shader "Custom/CircleView"
{
    Properties
    {
        [HideInInspector] _MainTex("Base Texture", 2D) = "white" {}
        _Color("Base Color", Color) = (1, 0, 0, 1)
        _Radius("Radius", Range(0, 1)) = 0.5
        _Threshold("Threshold", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque" 
            "Queue" = "Transparent"
        }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _MainTex;
            fixed4 _Color;
            fixed _Radius;
            fixed _Threshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float dist = distance(i.uv, float2(0.5, 0.5));
                col.rgb *= _Color.rgb;
                col.a = smoothstep(_Threshold, dist, _Radius) * smoothstep(dist, _Threshold, _Radius);
                return col;
            }
            ENDCG
        }
    }
}
