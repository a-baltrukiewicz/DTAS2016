DATABASES = \
{
    'default':
    {
        'ENGINE': 'django.db.backends.mysql',
        'OPTIONS':
        {
            'read_default_file': 'config.cnf',
        },
    }
}