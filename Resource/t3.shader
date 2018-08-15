float4 frag(vertexOutput input) : COLOR
		{
			//为什么在顶点着色器程序中已经将这两个向量归一化了，在此为什么还要归一化？
			//1>首先，在顶点程序中归一化是因为要在任何它们之间的方向上进行或多或少的插值
			//2>在此处又进行一次插值是因为，上面的插值过程会将归一化的值扭曲
			float3 normalDirection = normalize(input.normal);
			float3 viewDirection = normalize(input.viewDir);
			float4 tex = tex2D(_MainTex, input.tex.xy);
			float3 col = tex;
 
			float newOpacity = min(1.0, tex.a / abs(dot(viewDirection, normalDirection)));
			return float4(col, newOpacity);
		}
 
			ENDCG
		}
