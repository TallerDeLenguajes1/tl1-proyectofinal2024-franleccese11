# Rick And Morty Space Battle
## Descripcion general
Este juego es un juego de peleas simuladas por turnos cuya temática es la serie Rick y Morty. Tiene como enfoque contarnos una historia divertida sobre este famoso dúo y sus interacciones con un personajes que creará el usuario.
En esta entrega nuestro trío participará de un torneo de peleas multi galáctico con el propósito de ganar la esfera de la realidad y proteger la paz y el equilibrio del universo

## implementacion

### personajes 
Para el apartado de los personajes utilize una API de personajes de rick y morty. la misma cuenta con todos los personajes que aparecen en la serie, incluyendo datos especificos de cada uno como su especie, planeta de origen o primer episodio en el que salieron.
Si desean probarla este es el [LINK](https://rickandmortyapi.com/).
Esta API tiene los personajes en formato json, una vez que los deserializo y guardar 10 personajes aleatorios mediante mi fabrica de personajes los convierto a mi clase de personajes con algunas características consumidas de la API(muchas se descartan) y se agregan otras inventadas por mi o referentes al proyecto (estadísticas como armadura por ejemplo).

### consola
La estética de la consola como por ejemplo los dibujos de los marcos y la personalización en si de la ventana donde se muestra el juego fue mediante la biblioteca system.drawing. 


### Menú
El juego cuenta con un menú en bucle que puede manejarse con las arrow keys, un formato que a mi parecer es mucho más estético y profesional que el menú selector mediante números/teclas. Este fue implementado gracias a los tutoriales de un canal de youtube en inglés llamado [Michael Hadley](https://www.youtube.com/@mikewesthad).

### Dibujos ASCII
el juego cuenta con varios dibujos ASCII para enunciar los títulos de los capítulos de la historia,para crear los marcos de finales/semifinales/ la estética de las tarjetas de personajes. Todos estos fueron creados con generadores de arte ASCII.

### Batallas
Las batallas son simuladas,con una estetica de tarjeta de personajes cuidada y tienen como elemento dinamico los dialogos aleatorios de rick y morty. Los cuales se desarrollan de una u otra forma segun la efectividad de los golpes del protagonista.


## Historia

### Narrativa
Este es el plato fuerte del juego, una historia entretenida que intenta captar la dinámica de la serie de Rick And morty así como la esencia de este mítico dueto de personajes, podemos presenciar los típicos gags propios de la caracterización de ambos personajes así como los elementos narrativos de sci-fi que siempre están presentes en los capítulos de esta serie.

### Dialogos
Los Dialogos no siempre son los mismos, varian dependiendo de la partida y del desempeño de nuestro personaje creado en las batallas simuladas. De esta manera los dialogos y las interacciones de los personajes se vuelven un elemento dinamico que enriquece a la historia del juego.


### Instalacion

Para instalar el juego puedes simplemente clonar el repositorio con el comando git clone [https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-franleccese11](https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-franleccese11)