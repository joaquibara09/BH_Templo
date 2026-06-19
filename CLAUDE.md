# BH Templo — Proyecto Unity

Minijuego 3D de exploración y recolección contrarreloj. El jugador recorre un escenario escolar destruyendo objetos recogibles (pickables) antes de que se acabe el tiempo.

## Scripts en Assets/Scripts/

### GameManager.cs
- Maneja el temporizador (`tiempoRestante -= Time.deltaTime`)
- Al llegar a 0 llama `UIManagerScript.MostrarPantallaGameOver()` y congela con `Time.timeScale = 0`
- Al presionar R reinicia la escena con `SceneManager.LoadScene`
- Referencia pública a `UIManager`

### UIManager.cs
- Maneja todos los paneles y textos del HUD
- Paneles: `panelWin`, `panelGameOver`, `panelD` (asignados en Inspector)
- `panelD` contiene un hijo TextMeshPro llamado `Dest` — se obtiene con `GetComponentInChildren<TextMeshProUGUI>()` en Start, NO es una referencia pública
- Timer del Panel D usa `tiempoOcultarPanel -= Time.deltaTime` en Update (no coroutines)
- `tiempoOcultarPanel = -1f` significa inactivo
- Métodos clave: `MostrarPanelD(string)`, `MostrarDestruidoPorUnSegundo()`, `OcultarPanelD()`

### InteractiveArea.cs
- Vive en el jugador (debe ser hijo de FPSController, NO del Canvas ni de la cámara)
- Guarda referencia al pickable actualmente en rango: `pickableActual`
- En Update detecta la tecla E y destruye el pickable activo — UN SOLO objeto a la vez
- Métodos: `EntrarEnRango(Pickable p)`, `SalirDeRango(Pickable p)`, `AgregarPunto()`
- Referencias públicas a `UIManager` y `GameManager`

### Pickable.cs
- Cada objeto recogible tiene este script y un **Sphere Collider con Is Trigger = true**
- NO maneja input ni lógica de UI — solo avisa a InteractiveArea
- `OnTriggerEnter` → llama `interactiveArea.EntrarEnRango(this)`
- `OnTriggerExit` → llama `interactiveArea.SalirDeRango(this)`
- `Destruir()` → `Destroy(gameObject)`

## Jerarquía correcta en Unity

```
FPSController  (tag: Player)
├── FirstPersonCharacter  (Main Camera)
└── InteractiveArea  (script InteractiveArea.cs — sin collider propio)

Canvas
├── txtPuntaje
├── txtTimer
├── panelWin
├── panelGameOver
└── Panel_D
    └── Dest  (TextMeshPro)
```

## Problemas pendientes

- **InteractiveArea no está funcionando correctamente** — revisar que esté como hijo del FPSController y NO dentro del Canvas. Verificar que las referencias públicas `UIManagerScript` y `GameManagerScript` estén asignadas en el Inspector.
- **Panel_D**: asegurarse de que sea hijo del Canvas directamente, no del InteractiveArea.
- El `puntajeMaximo` se calcula con `FindObjectsOfType<Pickable>().Length` en Awake — si los pickables no están en escena al iniciar, el conteo puede fallar.

## Teclas
- **E** — destruir objeto (no usar D, es strafe del FPS Controller)
- **R** — reiniciar (solo cuando el juego terminó)
