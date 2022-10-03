# Hand Gesture Recognition Applied to the Interaction with 3D Models in Virtual Reality

## ABSTRACT
En este trabajo, presentamos un sistema de interacción humano-ordenador (HCI) basado en gestos manuales en tiempo real para controlar una aplicación de realidad virtual que aplica la sincronización de Oculus Rift y el brazalete Myo. Para ello se implementó un modelo de reconocimiento de gestos de mano (HGR) y una aplicación de realidad virtual (VR).
Los algoritmos K-Nearest Neighbors (KNN) y Dynamic Time Warping (DTW) se aplican para desarrollar el modelo HGR. Las entradas de este modelo son señales de 11 gestos con las manos medidos por Myo Armband y G-Force Pro utilizando sus sensores secos de electromiografía de superficie (EMG) incorporados y la unidad de medición inercial (IMU). La salida del modelo HGR es la etiqueta que identifica el gesto ejecutado por el usuario. La aplicación VR fue desarrollada por el motor de juego Unity utilizando Oculus Rift como dispositivo de entrada en el entorno virtual.
Permite navegar sobre una interfaz y manipular objetos tridimensionales (3D) aprovechando sus propiedades para una experiencia sofisticada. El modelo HGR se utiliza en la aplicación VR donde cada gesto identificado realiza una acción. El sistema presenta una comunicación natural a través de gestos con las manos en un entorno informático sofisticado. El sistema fue evaluado en términos de tiempo de respuesta, precisión de clasificación (82%) y usabilidad mediante la Escala de Usabilidad del Sistema (SUS).


### Instalación de software y librerías
Los archivos necesarios para la ejecución de la aplicación de realidad virtual se encuentran en la carpeta Instalador/VisorDeModelos3D.

### Visor de Modelos 3D
1. Manual de Usuario de la aplicación https://epnecuador-my.sharepoint.com/:b:/g/personal/laboratorio_ia_epn_edu_ec/EcOKDQH9BIlNuoDivXc2-d0B8uv91stS_8A9_5WOhFGhWg?e=PhKIEb
2. Código fuente script Matlab ejecución de tareas mediante el uso del teclado https://epnecuador-my.sharepoint.com/:u:/g/personal/laboratorio_ia_epn_edu_ec/EccDwcOmJY9FlUUUcV62op8BO6cl7hMorMo81Tbpha7_jg?e=DqKNp1
3. Manual de uso de la aplicación integrada con el modelo de reconocimiento de gestos https://epnecuador-my.sharepoint.com/:b:/g/personal/laboratorio_ia_epn_edu_ec/EUh1lZaddo1PvYMWWtuoaJQBmMm3kU9UhQDI4hBC2ZLwsA?e=rSkHBo


#### Instalación del software Oculus Rift para las gafas de realidad virtual
1. Visitar el enlace https://www.oculus.com/rift/setup/
2. Descargar "Oculus Rift Software"
3. Ejecutamos el archivo descargado
4. Seleccionamos el idioma deseado
5. Leer condiciones y seguir
6. Seleccionamos la ubicación donde se instalará el software
7. Una vez finalizada la instalación resta iniciar sesión mediante alguna cuenta en "Meta"
8. Proceder con la identificación del hardware mediante la aplicación "Oculus Rift Software"

#### Instalación de paquetes para Unity
1. Abrir el proyecto en Unity
2. Ir a la pestaña de "Windows" dentro del entorno de desarrollo Unity
3. Seleccionar Package Manager 
4. Buscar "TextMeshPro" e instalar
5. Buscar "XR Plugin Management" e instalar
6. Para instalar Oculus Integration SDK visitamos https://developer.oculus.com/downloads/package/unity-integration/ y descargar
7. Finalizada la descarga desde Unity, importaremos el nuevo paquete y seleccionamos Oculus Integration SDK
8. Reiniciamos el entorno de desarrollo Unity.


### Modelo de reconocimiento de gestos

#### Instalación del software Myo Connect Installer:
1. Damos doble clic sobre el icono del Myo Connect Installer.
2. Procedemos aceptando los permisos de administrador de esta manera podrá realizar cambios sobre el equipo.
3. En la ventana que despliega Myo connect Setup seleccionamos I AGREE de esta manera estamos de acuerdo que se realice el proceso de instalación.
4. Pulsamos el botón install y con esto se procede de manera automática con la instalación.
5. Por último, presionamos finalizar con la instalación.
6. Se desplegará una pantalla de sincronización del brazalete Myo Armband como se muestra en A3 que solicitará la conexión tanto del adaptador bluetooth como con el Myo Armband con el cable de alimentación, posterior a todo esto damos clic en continuar.
7. Saltamos el proceso de sincronización conectados a la red, hasta que muestre la ventana de A4 para proceder a desconectar el cable de alimentación.}
8. Para la sincronización de gestos con el brazalete se debe realizar el gesto WAVE OUT las veces que solicite
9. Cerramos todas las ventanas al finalizar la realización del gesto y observamos que el led de estado con el logo de THALMIC este en constante azul parpadeando cuando no esta colocado en el antebrazo o estático colocado en el antebrazo.

#### Librería Myo SDK Win 0.9.0:
1. Copiamos las dos carpetas correspondientes a myo-sdk-win-0.9.0 y MyoMex-master que se observan en A6 y las trasladamos al disco local (C:) de nuestro ordenador.
 ![image](https://user-images.githubusercontent.com/33075700/161841955-51f2975d-59be-4ded-8c9a-1472e5264742.png)
2. Nos dirigimos a las variables de entorno de Windows por medio del buscador desde SISTEMA como nos muestra A7, en la ventana que nos muestra damos clic en CONFIGURACIONES AVANZADAS DEL SISTEMA.
3. En la ventana propiedades del sistema seleccionamos la opción variable de entorno
4. En la ventana de variables de entorno seleccionamos donde se encuentra PATH y damos clic en editar
5. En la opción editar se desplegará una ventana en la cual deberemos crear un nuevo PATH cuya dirección debe ser la de la carpeta myo-sdk-win- 0.9.0/bin/ como muestra A11 posterior a esto, se da aceptar en todas las ventanas. IMPORTANTE: se debe reiniciar la computadora para que haga efecto los cambios en el path.
![image](https://user-images.githubusercontent.com/33075700/161842194-031b409b-2829-41b4-b955-bdf497761fb4.png)

#### Librería Myo Mex Master:
1. Ingresamos a la versión de Matlab que se utiliza para el desarrollo del software e ingresamos en la pestaña ENVIRONMENT y seleccionamos SET PATH como se muestra en A12.
![image](https://user-images.githubusercontent.com/33075700/161842448-c61e958f-f773-4c64-b931-a394ec422bf9.png)
2. En la ventana del SET PATH nos dirigimos al botón ADD WITH SUBFOLDERS como en A13.
![image](https://user-images.githubusercontent.com/33075700/161842492-f53931bb-b13f-4069-9253-745ae144483b.png)
3. Buscando en el disco local C la Carpeta de Myo Mex master y se selecciona, damos aceptar en todas las ventanas y cerramos como se observa en A14.
![image](https://user-images.githubusercontent.com/33075700/161842557-434ea814-157d-4fa7-aa04-4a80448b6099.png)

#### Instalación del Toolbox Mingw-w64:
1. Ingresando a Matlab en la sección ENVIRONMENT presionamos la opción ADD-ONS y seleccionamos la opción GET ADD-ONS como muestra A15.
![image](https://user-images.githubusercontent.com/33075700/161842644-e7f70ccc-c821-4d4d-a3fa-e030a4c9dbc3.png)
2. En la ventana que se despliega como se ve en A16, en el buscador se escribe MINGW-W64 se procede con la descarga y ce cierra la ventana.
![image](https://user-images.githubusercontent.com/33075700/161842705-be08b488-82ec-4760-a8b3-5873eddc2362.png)

#### Scripts de inicialización:
1. Dentro del directorio Myo_Mex_master se encuentra un script de Matlab el cual se lo debe abrir como se muestra en A17 y arrancar una sola vez en el proceso de instalación de la librerías y softwares.
2. En la misma carpeta que se habla en el apartado anterior abrimos el script MyoMex_Quickstart.m y se procede a ejecutar mostrando información de señales proporcionadas por el Myo Armband de EMG y la IMU
![image](https://user-images.githubusercontent.com/33075700/161842890-87cd84cb-1f0b-4827-84d5-c0665db25e55.png)

#### Ejecución de script de inicialización.
1. Dentro del script como se muestra en A19 de inicialización se procede a ejecutar y de esta manera el Myo Armband enviara los datos necesarios de la IMU y EMG, este proceso se debe realizar una sola vez antes de realizar el reconocimiento de los gestos o cuando en la Workspace no muestre las variables de A20.
![image](https://user-images.githubusercontent.com/33075700/161843035-2f6c4110-b14b-4d45-81c7-b30f41acbf59.png)

### Ejecución de script principal.
1. Al ejecutar el script del software desarrollado se desplegará un menú interactivo con el usuario como se muestra en A20.
![image](https://user-images.githubusercontent.com/33075700/161843271-2809d64a-771b-491e-ad2f-f7481bad3b54.png)
2. Dentro del menú al seleccionar la opción 1 el programa pedirá al usuario mantener el brazo en forma de reposo para la toma de la muestra inicial como muestra A21.
![image](https://user-images.githubusercontent.com/33075700/161843320-67b15a0f-3c3e-4bc5-879e-0710541a3b28.png)
3. Después de haber tomado la muestra inicial el programa está en la capacidad de realizar el reconocimiento de los gestos como se muestra en A22.
![image](https://user-images.githubusercontent.com/33075700/161843412-f34559a6-f444-4ccf-a294-69c98b87bb7f.png)
4. El programa esta en la capacidad de reconocimiento de gestos a partir de la toma de muestra inicial ya sea sin colocar en el antebrazo o colocado en el antebrazo, esto dependería del punto inicial de referencia de la toma de la muestra.
5. Después de un determinado tiempo el programa desplegara nuevamente el menú donde se puede seleccionar la opción de salir.

#### Colocación del dispositivo Myo Armband en el antebrazo.
1. La figura A23 muestra las formas en la cuales se podría colocar el dispositivo al realizar el reconocimiento de los movimientos.
![image](https://user-images.githubusercontent.com/33075700/161843513-b098fa4f-3c8d-4ead-8a88-39ac3332d123.png)
2. Si el reconocimiento se lo hace sin estar colocado en el antebrazo el Myo Armband tendrá la misma guía horizontal del brazo para la muestra inicial.

## Demostración
Ambos componentes al ser instalados correctamente funcionan como se observa en https://www.youtube.com/watch?v=NQcEOSXeYqc
