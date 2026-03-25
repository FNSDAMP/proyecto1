# proyecto1

*Descripcion: El simulador de decisiones para plataforma de streaming ayuda a decidir que contenidos pueden publicarse despues de pasar varias condiciones, DOnde el sistema no almacena listas de conteidos, coada solucion se evalua en el momento y el programa mantiene las estadisticas generales en cada prueba.

*Instrucciones: . Reglas de Seguridad y Horarios (Protección al Menor)
Basado en la clasificación de edad, el sistema restringe el horario de transmisión para proteger a las audiencias vulnerables:
Clasificación Todo Público (TP): Sin restricción de horario (00:00 - 23:59).
Clasificación +13: Permitido únicamente en la franja de 06:00 a 22:00.
Clasificación +18: Permitido únicamente en la franja nocturna de 22:00 a 05:00.
5.3. Reglas de Integridad y Calidad
Estas reglas cruzan múltiples variables para asegurar que el contenido premium cumpla con estándares mínimos:
Validación de Calidad Adulta: Todo contenido con clasificación +18 debe poseer obligatoriamente un nivel de Producción 2 (Media) o 3 (Alta). Si el nivel es 1 (Baja), el sistema rechazará la carga.
Criterio de Impacto: * Se considera Impacto Alto si la producción es Alta (3) O si la duración supera los 120 min O si se programa después de las 20:00 hrs.
Se considera Impacto Medio si la producción es Media (2) O la duración es estándar.
En cualquier otro caso, el impacto se registra como Bajo.
5.4. Lógica de Decisión Final
Una vez procesadas las reglas anteriores, el sistema asigna un estado final:
Publicar: Si esValido es verdadero y el impacto es Bajo o Medio (con producción Alta).
Publicar con Ajustes: Si el impacto es Medio y la producción es Media.
Enviar a Revisión: Si el impacto es Alto.
Rechazado: Si falla cualquier regla.

*Explicaion del proyecto: El proyecto consiste únicamente en un Simulador de Gestión de Contenidos para una Plataforma de Streaming, el cual se presenta con varias condiciones que determinará si una película, una serie, un documental o un evento en directo puede ser publicado o no en la plataforma.
¿Cómo funciona? 
Captura de datos: el usuario introduce datos técnicos (duración, nivel de producción) y de programación (clasificación por edades, hora de aparición).
Validación de Reglas: El programa aplica filtros lógicos para comprobar:
• Seguridad: Que el contenido para adultos no puede ser emitido en el horario infantil.
• Calidad: Que el contenido +18 no puede estar marcado por un nivel de producción bajo.
• Formato: Que la duración es la adecuada para cada tipo de contenido (una película no debe tener una duración inferior a 60 minutos).
• Cálculo de Impacto: Véase si el contenido es de impacto Bajo, Medio o Alto como resultado de la producción, la duración y la hora estelar (Prime Time).
• Decisión Final: El programa emite un veredicto: Publicar, Publicar con Modificaciones, Enviar para Revisión (alto impacto) o Rechazado.
• Estadísticas: Finalmente genera un reporte acumulado de todo lo procesado a lo largo de la jornada para la administración y que, a su vez, servirá como base de decisiones.

link del video: https://youtu.be/j_Wnb3aCeYg    
