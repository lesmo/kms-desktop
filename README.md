> :warning: Éste repositorio está **muerto**, y permanecerá aquí sin modificaciones sólo con propósito histórico.

<p align="center">
  <img src="kms.png" />
</p>

La idea básica de KMS es tener una pulsera con una serie de sensores y que esta se comunique con nuestro smartphone
para enviar datos sobre distancia recorrida, calorías quemadas, horas de sueño, así como demás estadísticas para
mantener un control y una cuantificación de nuestras actividades físicas.

~ [Rodrigo Garrido (Xataka)](https://www.xataka.com.mx/accesorios/kms-en-mexico-tambien-se-prepara-una-pulsera-cuantificadora)

# KMS Desktop (Windows)
No era tan común decirle así tratándose de software para PC, pero ésta es la _"App"_ para Windows de KMS. Ésta
permitía conectarse al dispositivo KMS vía USB y descargar la información de movimiento almacenada en la pulsera.

También fue necesario generar un _driver_ para Windows para permitir la comunicación con la pulsera vía USB, y
todo lo que se proceso conllevó. El driver únicamente abría un puente de comunicación _serial_, por lo que el driver
no tuvo que pasar por el riguroso proceso de validación que usualmente tiene un driver que ejecuta instrucciones
a niveles más cercanos a Ring 0.

Agregué un rudimentario mecanismo de animaciones similar a lo que hoy es muy común ver en ventanas emergentes
de Mac OS, lo que la hacía destacar por sobre cualquier otra aplicación.

Publicarla en la ahora llamada Microsoft Store en su momento no era posible dada la necesidad de ejecutar
instrucciones fuera del sandbox de las Universal Apps de Windows. Hoy en día tal vez existan formas de lograrlo.

Hoy en día incluso hay APIs en los browsers para interactuar con dispositivos USB. Quién lo diría.
