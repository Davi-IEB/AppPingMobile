"alerta": 0,
"sequencia": 1,
"num_programa": 27630,
"data_programa": "09\/13\/2022 11:11",
"num_ordem": 13721499,
"ies_situa": 4,
"cod_item_cliente": 52096923,
"cod_item": 10000004320010,
"operacao": "055 - MONTAR COMP.E SOLDAR PONTO",
"qtd_planej": 2200,
"qtd_boas": 1591,
"qtd_percentual": 0.723

SELECT
PM.cod_empresa,
PM.alerta,
PM.sequencia,
PM.num_programa,
PM.data_programa,
PM.num_ordem,
ORD.ies_situa,
CP.cod_item_cliente,
ORD.cod_item,
trim(MPI.operacao) || ' - ' || trim(OP.den_operac) AS operacao,
ORD.qtd_planej,
ORD.qtd_boas,
CAST(ORD.qtd_boas / ORD.qtd_planej AS DECIMAL(10,3)) AS qtd_percentual

FROM tb_programa_maquina_970 PM
LEFT JOIN ordens ORD ON ORD.cod_empresa=PM.cod_empresa AND ORD.num_ordem=PM.num_ordem
LEFT JOIN ciclo_peca_970 CP ON CP.cod_empresa=ORD.cod_empresa AND CP.cod_item=ORD.cod_item
LEFT JOIN man_processo_item MPI ON MPI.empresa=ORD.cod_empresa AND MPI.item=ORD.cod_item
LEFT JOIN operacao OP ON OP.cod_empresa=MPI.empresa AND OP.cod_operac=MPI.operacao

WHERE ORD.ies_situa IN('2','3','4')
AND MPI.operacao NOT IN('042','199')
AND MPI.validade_final IS NULL

