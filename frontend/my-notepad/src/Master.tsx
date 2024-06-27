import React from 'react';
import { UploadOutlined, UserOutlined, VideoCameraOutlined, EditOutlined } from '@ant-design/icons';
import { Button, ConfigProvider, Divider, Flex, Grid, Input, Layout, Menu, Space, theme } from 'antd';
import Title from 'antd/es/typography/Title';
import TextArea from 'antd/es/input/TextArea';

const { Header, Content, Footer, Sider } = Layout;
const { useBreakpoint } = Grid;

const items: {
    key: string,
    label: string
}[] = [];

for (var i = 1; i <= 30; i++) {
    items.push({
        key: String(i),
        label: `Nota ${i}`
    })
}

export default function Master() {
    const tamanhoTela = useBreakpoint();

    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();

    return (
        <ConfigProvider
            theme={{
                components: {
                    Layout: {
                        headerBg: '#92b6ff', //cor de fundo do cabeçalho
                        siderBg: '#b3ccff', //cor de fundo da seção lateral
                        footerBg: '#92b6ff', //cor de fundo do rodapé
                        headerHeight: 80 //altura do cabeçalho em pixels
                    },
                    Menu: {
                        darkItemBg: '#b3ccff', //cor de fundo do menu no tema escuro
                        darkItemColor: '#004d99', //cor do texto do menu no tema escuro
                        darkItemSelectedBg: '#92b6ff' //cor de fundo do item selecionado do menu no tema escuro
                    }
                }
            }}
        >
            <Layout style={{ height: '100vh' }}>
                <Header style={{ padding: 0, textAlign: 'center' }}>
                    <Title className='titulo-app' style={{ color: 'white', margin: 10 }}>MyNotepad</Title>
                </Header>
                <Layout style={{ height: '100vh' }}>
                    <Sider
                        breakpoint="lg"
                        collapsedWidth="0"
                        onBreakpoint={(broken) => {
                            console.log(broken);
                        }}
                        onCollapse={(collapsed, type) => {
                            console.log(collapsed, type);
                        }}
                        style={{
                            paddingTop: 24,
                            paddingBottom: 24,
                            // overflow: tamanhoTela.lg ? 'auto' : 'initial'
                            overflow: 'auto'
                        }}
                    >
                        <div style={{
                            paddingLeft: 4,
                            paddingRight: 4
                        }}>
                            <Button type='primary' className='btn-nova-nota' icon={<EditOutlined />} size='large' block>
                                Nova nota
                            </Button>
                        </div>
                        <Divider />
                        <Menu theme="dark" mode="inline" defaultSelectedKeys={['1']} items={items} style={{ fontWeight: 600 }} />
                    </Sider>
                    <Layout>
                        <Content style={{ margin: '24px 16px 0', overflow: 'auto' }}>
                            <div
                                style={{
                                    padding: 24,
                                    minHeight: '100%',
                                    background: colorBgContainer,
                                    borderRadius: borderRadiusLG,
                                }}
                            >
                                <Title level={3}>Nova Nota</Title>
                                <Space direction='vertical' style={{ width: '100%' }}>
                                    <Input size='large' placeholder='Título' />
                                    <TextArea
                                        showCount
                                        placeholder="Escreva aqui sua nota..."
                                        style={{ minHeight: '300px', resize: 'none' }}
                                    />
                                </Space>
                            </div>
                        </Content>
                    </Layout>
                </Layout>
                <Layout>
                    <Footer style={{ textAlign: 'center', color: '#004d99', fontWeight: 600, zIndex: 1 }}>
                        ©{new Date().getFullYear()} Created by Vitor Eduardo
                    </Footer>
                </Layout>
            </Layout>
        </ConfigProvider>
    )
}