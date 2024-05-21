

document.getElementById("loginButton").addEventListener("click", function() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const userData = {
        username: username,
        password: password
    };

    fetch("http://localhost:5005/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(userData)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error("Error al iniciar sesión");
        }
        return response.json();
    })
    .then(data => {
        const sessionToken = data.token;
        // Aquí puedes manejar el token de sesión como desees
        console.log("Token de sesión:", sessionToken);
    })
    .catch(error => {
        alert("Error:", error);
    });
});
