<template>

    <section class="c-auth">

        <div class="login-form auth-card">

            <input type="text" name="login" class="login-form__login" placeholder="Логин" />
            <input type="password" name="password" class="login-form__password" placeholder="Пароль" />

            <input type="submit" class="login-form__submit yellow-button" value="Вход" />

        </div>


        <div class="or-register auth-card">
            <router-link to="/auth/register" class="or-register__register-button yellow-button">Зарегистрироваться!</router-link>
        </div>

    </section>

</template>

<style lang="less">

.page-content {
	background: #6dacdc;
	display: flex;
	align-items: center;
	justify-content: center;
	flex-direction: column;
}

.login-form {
    margin-top: -150px; // чего

    input:not(:first-child) { margin-top: 30px; }
}

.or-register { margin-top: 30px; }

</style>
