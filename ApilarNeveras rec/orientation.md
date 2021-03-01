# About

Se tiene una secuencia de neveras puestas en el suelo. Cada nevera tiene un peso específico pero todas las neveras tienen el mismo tamaño. Se puede poner una nevera sobre otra formando pilas y a su vez pilas sobre otras etc. El apilamiento sólo es posible entre neveras (o pila de neveras) que estén una al lado de la otra. El costo de apilar una pila A sobre una pila B es igual a la altura de B por el peso de A (considere una nevera como una pila de altura 1).

Usted deberá implementar un método que dado la secuencia de pesos de las neveras determine el menor costo que se puede lograr para apilarlas todas en una única pila.

El ejemplo muestra el mejor caso para 3 neveras con pesos 4, 1 y 6 resultando costo total 6.

|Pilas|Movimiento|Costo|
|---|---|---|
|4, 1, 6|1 > 4|1*1 = 1|
|(4, 1), 6|(4, 1) > 6|(4 + 1)*1 = 5|

Note que se hubiera movido la nevera de peso 6 para la pila (4,1) el costo hubiera sido 6 * 2 = 12.

int MejorAcomodo (int[] neveras) {…}