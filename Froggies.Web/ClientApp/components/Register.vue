<template>

    <section class="c-register">


        <div class="register-form auth-card">

            <input type="text" name="login" placeholder="Логин" />
            <input type="password" name="password" placeholder="Пароль" />

            <input type="submit" class="yellow-button" value="Зарегистрироваться!" />

        </div>


    </section>

</template>

<style lang="less">

// Это повторяется здесь и в Auth.vue
// С этим было бы круто что-то сделать.
.page-content {
	background: #6dacdc;
	display: flex;
	align-items: center;
	justify-content: center;
	flex-direction: column;
}

.register-form {
    input {
        &:not(:first-child) { margin-top: 30px; }
        &[type=submit] { width: 100%; }
    }
}


</style>