<template>

    <section class="auth-c">

        <div class="login-form auth-card">

            <input type="text" name="login" class="login-form__login" placeholder="Логин" />
            <input type="password" name="password" class="login-form__password" placeholder="Пароль" />

            <input type="submit" class="login-form__submit yellow-button" value="Вход" />

        </div>


        <div class="or-register auth-card">
            <a href="/auth/register" class="or-register__register-button yellow-button">Зарегистрироваться!</a>
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

	.auth-card {
        width: 300px;
        padding: 40px;
        background: #68c72f;
        border-bottom: 5px solid #3b9c00;
	}

	.login-form {
		margin-top: -150px;

		input {
			height: 50px;
			font-size: 20px;

			&[type=text], &[type=password] {
				width: 100%;
				padding-left: 20px;
				box-sizing: border-box;
				border-top: 3px solid #3b9c00;
			}
		}

		&__password, &__submit { margin-top: 30px; }
	}

	.or-register { margin-top: 30px; }
}

</style>
