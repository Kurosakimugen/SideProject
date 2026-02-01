<?php

class Config
{
    protected static array $config = [
        'app' => [
            'name' => 'Warframe Builder',
            'env'  => 'local',
        ],
    ];

    public static function get(string $key, $default = null)
    {
        $keys = explode('.', $key);
        $value = self::$config;

        foreach ($keys as $segment) {
            if (!isset($value[$segment])) {
                return $default;
            }
            $value = $value[$segment];
        }

        return $value;
    }
}
